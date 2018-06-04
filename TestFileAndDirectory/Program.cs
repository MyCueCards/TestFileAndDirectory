/********************************************************************
 * Assignment from SDEV 240                                         *
 * Coded by: Harley Ehrman                                          *
 *                                                                  *
 * From book:                                                       *
 * Microsoft Visual C# 2015:                                        *
 * An Introduction to Object-Oriented Programming 6th Edition       *
 * by Joyce Farrell                                                 *
 *                                                                  *
 * Instructions (Page 702, Exercise 1):                             *
 * Create a program named TestFileAndDirectory that allows a user   *
 * to continually enter directory names until the user types end.   *
 * If the directory name exists, display a list of the files in it; *
 * otherwise, display a message indicating the directory does not   *
 * exist. If the directory exists and files are listed, prompt the  *
 * user to enter one of the filenames. If the file exists, display  *
 * its creation date and time; otherwise, display a message         *
 * indicating the file does not exist. Create as many test          *
 * directories and files as necessary to test your program.         *
 ********************************************************************/
using System;
using System.IO;

namespace TestFileAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string DirectoryName;

            while (true)
            {
                Console.WriteLine("Enter A Folder: ");
                DirectoryName = Console.ReadLine();

                if (File.Exists(DirectoryName))
                {
                    // This DirectoryName is a file
                    ProcessFile(DirectoryName);
                    ExitDecision();
                }
                else if (Directory.Exists(DirectoryName))
                {
                    // This DirectoryName is a directory
                    ProcessDirectory(DirectoryName);
                    Console.WriteLine("Type In A File From That Directory");
                    string fileName = Console.ReadLine();
                    Console.WriteLine("The creation date and time of {0} is {1}.", fileName, File.GetCreationTime(fileName));
                    ExitDecision();
                }
                else
                {
                    Console.WriteLine("Directory {0} does not exist.", DirectoryName);
                    ExitDecision();
                }
            }
            
        }
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        // Insert logic for processing found files here.
        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }
        // Ask use to exit/not exit program
        public static void ExitDecision()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + "Type the word \"end\" to end program." + "\n" + "Otherwise, press any key to continue.");
            string choice = Console.ReadLine();
            if (choice == "end")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.ResetColor();
            }
        }
    }
}
