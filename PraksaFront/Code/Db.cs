namespace PraksaFront.Code
{
    public static class Db
    {
        static object Lock = new object();

        public static void DoSomething()
        {
            lock (Lock)
            {


            }
        }
    }
}