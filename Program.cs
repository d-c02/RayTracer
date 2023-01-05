// See https://aka.ms/new-console-template for more information

void Render(int h, int w)
{
    string fileName = "out.ppm";
    string curDirectory = Directory.GetCurrentDirectory();
    Console.WriteLine(curDirectory);
    using (StreamWriter outputFile = new StreamWriter(Path.Combine(curDirectory, fileName)))
    {
        outputFile.WriteLine("P3");
        outputFile.WriteLine(h + " " + w);
        outputFile.WriteLine("255");
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                outputFile.WriteLine("0 0 0");
            }
        }
    }
}

Render(256, 256);
