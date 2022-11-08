namespace Algorithms.Multiply
{
    public static class MatrixMultiplication
    {
        public static int OperationCount = 0;

        public static int[,] MultiplyMatrices(int[,] A, int[,] B)
        {
            var result = new int[A.GetLength(0), B.GetLength(1)];

            var multiplyMatrices = Multiply(A, B);

            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j< result.GetLength(1); j++)
                    result[i, j] = multiplyMatrices[i, j];

            return result;
        }

        private static int[,] Multiply(int[,] A, int[,] B)
        {
            int rows = Math.Max(A.GetLength(1), B.GetLength(1));
            int cols = Math.Max(A.GetLength(0), B.GetLength(0));

            if (rows <= 2 && rows == cols)
                return BlockMultiply(A, B);

            A = ExpandMatrix(A, rows, cols);
            B = ExpandMatrix(B, rows, cols);

            int n = A.GetLength(0);

            var C = new int[n, n];

            var A1 = CopyPartOfMatrix(A, 0, 0);
            var A2 = CopyPartOfMatrix(A, 0, n / 2);
            var A3 = CopyPartOfMatrix(A, n / 2, 0);
            var A4 = CopyPartOfMatrix(A, n / 2, n / 2);

            var B1 = CopyPartOfMatrix(B, 0, 0);
            var B2 = CopyPartOfMatrix(B, 0, n / 2);
            var B3 = CopyPartOfMatrix(B, n / 2, 0);
            var B4 = CopyPartOfMatrix(B, n / 2, n / 2);

            var M1 = Multiply(SubtractMatrices(A2, A4), SumMatrices(B3, B4)); // (A2 - A4) * (B3 + B4)
            var M2 = Multiply(SumMatrices(A1, A4), SumMatrices(B1, B4)); // (A1 + A4) * (B1 + B4)
            var M3 = Multiply(SubtractMatrices(A1, A3), SumMatrices(B1, B2)); // (A1 - A3) * (B1 + B2)
            var M4 = Multiply(SumMatrices(A1, A2), B4); // (A2 + A4) * B4
            var M5 = Multiply(A1, SubtractMatrices(B2, B4)); //  A1 * (B2 - B4)
            var M6 = Multiply(A4, SubtractMatrices(B3, B1)); // (B3 - B1) * A4
            var M7 = Multiply(SumMatrices(A3, A4), B1); // (A3 + A4) * B1

            var C1 = SubtractMatrices(SumMatrices(M1, M2), SumMatrices(M4, M6)); // M1 + M2 - M4 + M6
            var C2 = SumMatrices(M4, M5); // M4 + M5
            var C3 = SumMatrices(M6, M7); // M6 + M7
            var C4 = SumMatrices(SubtractMatrices(M2, M3), SubtractMatrices(M5, M7)); // M2 - M3 + M5 - M7

            InsertToMatrix(C1, C, 0, 0);
            InsertToMatrix(C2, C, 0, n / 2);
            InsertToMatrix(C3, C, n / 2, 0);
            InsertToMatrix(C4, C, n / 2, n / 2);

            return C;
        }

        private static void InsertToMatrix(int[,] fromA, int[,] toB, int fromRow, int fromCol)
        {
            var n = toB.GetLength(0) / 2;

            var toRow = fromRow + n;
            var toCol = fromCol + n;

            for (int i = fromRow; i < toRow; i++)
                for (int j = fromCol; j < toCol; j++)
                    toB[i, j] = fromA[i - fromRow, j - fromCol];
        }

        public static int[,] BlockMultiply(int[,] A, int[,] B)
        {
            if (A.GetLength(0) > 2 || A.GetLength(1) > 2 || B.GetLength(0) > 2 || B.GetLength(1) > 2)
                throw new ArgumentException();

            return new int[,] {
                { A[0, 0] * B[0, 0] + A[0, 1] * B[1, 0], A[0, 0] * B[0, 1] + A[0, 1] * B[1, 1] },
                { A[1, 0] * B[0, 0] + A[1, 1] * B[1, 0], A[1, 0] * B[0, 1] + A[1, 1] * B[1, 1] } };
        }

        private static int[,] CopyPartOfMatrix(int[,] A, int fromRow, int fromCol)
        {
            var n = A.GetLength(0) / 2;
            var result = new int[n, n];

            var toRow = fromRow + n;
            var toCol = fromCol + n;

            for (int i = fromRow; i < toRow; i++)
                for (int j = fromCol; j < toCol; j++)
                    result[i - fromRow, j - fromCol] = A[i, j];

            return result;
        }

        private static int[,] SumMatrices(int[,] A, int[,] B)
        {
            return FoldingMatrices(A, B);
        }

        private static int[,] SubtractMatrices(int[,] A, int[,] B)
        {
            return FoldingMatrices(A, B, -1);
        }

        private static int[,] FoldingMatrices(int[,] A, int[,] B, int sign = 1)
        {
            var C = new int[A.GetLength(0), A.GetLength(0)];

            for (int i = 0; i < C.GetLength(0); i++)
                for (int j = 0; j < C.GetLength(0); j++)
                {
                    if (A[i, j] == 0 && B[i, j] == 0)
                        continue;

                    C[i, j] = A[i, j] + sign * B[i, j];
                    OperationCount++;
                }

            return C;
        }

        private static int[,] ExpandMatrix(int[,] matrix, int rows, int cols)
        {
            return ExpandMatrixWidth(ExpandMatrixHeight(matrix, rows), cols);
        }

        private static int[,] ExpandMatrixHeight(int[,] matrix, int n)
        {
            if (matrix == null)
                throw new ArgumentException();

            while ((n & (n - 1)) != 0)
                n++;

            var result = new int[n, matrix.GetLength(1)];

            CopyMatrix(matrix, result);

            return result;
        }

        private static int[,] ExpandMatrixWidth(int[,] matrix, int n)
        {
            if (matrix == null)
                throw new ArgumentException();

            while ((n & (n - 1)) != 0)
                n++;

            var result = new int[matrix.GetLength(0), n];

            CopyMatrix(matrix, result);

            return result;
        }

        private static void CopyMatrix(int[,] fromMatrix, int[,] toMatrix)
        {
            for (int i = 0; i < fromMatrix.GetLength(0); i++)
                for (int j = 0; j < fromMatrix.GetLength(1); j++)
                    toMatrix[i, j] = fromMatrix[i, j];
        }
    }
}
