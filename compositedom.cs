using System;
using System.Collections.Generic;

abstract class FileSystemComponent
{
    public string Name;

    protected FileSystemComponent(string name)
    {
        Name = name;
    }

    public abstract void Display(int indent = 0);

    public abstract int GetSize();
}

class File : FileSystemComponent
{
    private int Size;

    public File(string name, int size) : base(name)
    {
        Size = size;
    }

    public override void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"File: {Name}, Size: {Size} KB");
    }

    public override int GetSize()
    {
        return Size;
    }
}

class Directory : FileSystemComponent
{
    private List<FileSystemComponent> Components = new List<FileSystemComponent>();

    public Directory(string name) : base(name) { }

    public void Add(FileSystemComponent component)
    {
        if (!Components.Contains(component))
        {
            Components.Add(component);
        }
        else
        {
            Console.WriteLine($"{component.Name} уже существует в папке {Name}.");
        }
    }

    public void Remove(FileSystemComponent component)
    {
        if (Components.Contains(component))
        {
            Components.Remove(component);
        }
        else
        {
            Console.WriteLine($"{component.Name} не найден в папке {Name}.");
        }
    }

    public override void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + $"Directory: {Name}");
        foreach (var component in Components)
        {
            component.Display(indent + 2);
        }
    }

    public override int GetSize()
    {
        int totalSize = 0;
        foreach (var component in Components)
        {
            totalSize += component.GetSize();
        }
        return totalSize;
    }
}

class Program
{
    static void Main(string[] args)
    {
        File file1 = new File("File1.txt", 500);
        File file2 = new File("File2.txt", 300);
        File file3 = new File("File3.txt", 800);

        Directory folder1 = new Directory("Folder1");
        Directory folder2 = new Directory("Folder2");
        Directory rootFolder = new Directory("RootFolder");

        folder1.Add(file1);
        folder1.Add(file2);
        folder2.Add(file3);
        rootFolder.Add(folder1);
        rootFolder.Add(folder2);

        rootFolder.Display();
        Console.WriteLine($"\nTotal Size of RootFolder: {rootFolder.GetSize()} KB");
    }
}
