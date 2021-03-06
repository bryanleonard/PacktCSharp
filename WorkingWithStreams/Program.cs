﻿using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;

namespace WorkingWithStreams
{
    class Program
    {
        static void Main(string[] args)
        {

            //WorkWithText();
            WorkWithXml();
            WorkWithCompression();

        }

        // define array of pilot call signs
        static string[] callsigns = new string[]
        {
            "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Helo", "Racetrack", "Nimrod", "Petey", "Mojo"
        };

        static void WorkWithXml()
        {
            FileStream xmlFileStream = null;
            XmlWriter xml = null;
            try
            {
                // define a file to write to
                string xmlFile = Combine(CurrentDirectory, "streams.xml");

                // create a file streams
                xmlFileStream = File.Create(xmlFile);

                // wrap the file stream in an XML writer helper and automatically indent nested elements
                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

                // write the XML declaration
                xml.WriteStartDocument();

                // write a root element
                xml.WriteStartElement("callsigns");

                // enumerate the string writing each one to the stream
                foreach (string item in callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                // close helper and stream
                xml.Close();
                xmlFileStream.Close();

                // output all the contents of the file to the Console 
                WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes.");
                WriteLine(File.ReadAllText(xmlFile));
            }
            catch (Exception ex)
            {
                // if the path doesn't exist, the exception will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}.");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }
                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The file stream's unmanaged resources have been disposed."); 
                }
            }

            // alternative way of writing this stuff without a catch
            // CurrentDirectory could also be a path
            using (FileStream file2 = File.OpenWrite(Path.Combine(CurrentDirectory, "file2.txt")))
            {
                using (StreamWriter writer2 = new StreamWriter(file2))
                {
                    try
                    {
                        writer2.WriteLine("Welcome, .NET Core!");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{ex.GetType()} says {ex.Message}");
                    }
                } // automatically calls Dispose if the object is not null 
            } // automatically calls Dispose if the object is not null
        }



        static void WorkWithCompression()
        {
            // compress the XML output 
            string gzipFilePath = Combine(CurrentDirectory, "streams.gzip");

            FileStream gzipFile = File.Create(gzipFilePath);
            using (GZipStream compressor =
            new GZipStream(gzipFile, CompressionMode.Compress))
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");
                    foreach (string item in callsigns)
                    {
                        xmlGzip.WriteElementString("callsign", item);
                    }
                }
            } // also closes the underlying stream 

            // output all the contents of the compressed file to the Console 
            WriteLine($"{gzipFilePath} contains { new FileInfo(gzipFilePath).Length} bytes."); 
            WriteLine(File.ReadAllText(gzipFilePath));

            // read a compressed file 
            WriteLine("Reading the compressed XML file:");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);
            using (GZipStream decompressor = new GZipStream(gzipFile, CompressionMode.Decompress))
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        // check if we are currently on an element node named callsign 
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name ==
                        "callsign"))
                        {
                            reader.Read(); // move to the Text node inside the element 
                            WriteLine($"{reader.Value}"); // read its value 
                        }
                    }
                }
            }
        }





        static void WorkWithText()
        {
            // define a file to write to
            string textFile = Combine(CurrentDirectory, "streams.txt");

            // create a text file a return a helper writer
            StreamWriter text = File.CreateText(textFile);

            // enumerate the strings, writing each one to the stream
            foreach( string item in callsigns)
            {
                text.WriteLine(item);
            }

            // release resources
            text.Close();

            // output the contents of the file to the Console 
            WriteLine($"{textFile} contains { new FileInfo(textFile).Length} bytes.");
            WriteLine(File.ReadAllText(textFile));
        }
    }
}
