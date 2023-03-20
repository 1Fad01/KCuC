string fileName = @"\\Desktop-0lj979m\ksis\lab3-6.txt";
using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
{
    using (StreamWriter writer = new StreamWriter(stream))
    {
        writer.WriteLine("Лабораторную работу выполняли: студенты группы 10701121 Длусский К.Ю. и Качан И.В.");
    }
}
