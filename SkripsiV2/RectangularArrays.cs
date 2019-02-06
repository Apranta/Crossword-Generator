internal static class RectangularArrays
{
    internal static char[][] ReturnRectangularCharArray(int size1, int size2)
    {
        char[][] newArray = new char[size1][];
        for (int array1 = 0; array1 < size1; array1++)
        {
            newArray[array1] = new char[size2];
        }

        return newArray;
    }
}