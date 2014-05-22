namespace ControlFlow.Loops
{
    using System;

    class Loop
    {
        static void Main()
        {
            int[] integersArray = new int[100];
            int expectedValue = 0;

            for (int i = 0; i < integersArray.Length; i++)
            {
                Console.WriteLine(integersArray[i]);

                if (i % 10 == 0 && integersArray[i] == expectedValue)
                {
                    Console.WriteLine("Value found");
                    break;
                }
            }
        }
    }
}
