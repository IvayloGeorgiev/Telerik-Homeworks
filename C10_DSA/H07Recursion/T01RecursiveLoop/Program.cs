namespace T01RecursiveLoop
{
    class Program
    {
        static void Main(string[] args)
        {            
            Loop(3, 0);
        }

        private static void Loop(int desiredDepth, int curDepth)
        {
            if (curDepth == desiredDepth)
            {                
                return;
            }
            for (int i = 0; i < desiredDepth; i++)
            {                
                Loop(desiredDepth, curDepth + 1);
            }
        }
    }
}
