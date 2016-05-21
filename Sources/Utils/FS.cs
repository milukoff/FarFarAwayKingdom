using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography;

namespace Utils
{
    public class FS
    {
        public static void CompressFile(string sourceFileName, string destinationFileName)
        {
            FileStream outStream;
            FileStream inStream;

            //Check if the source file exist.            
            if (File.Exists(sourceFileName))
            {
                //Read the input file
                inStream = File.OpenRead(sourceFileName);
                //Check if the destination file exist else create once
                outStream = File.Open(destinationFileName, FileMode.OpenOrCreate);

                GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress);

                //Now create a byte array to hold the contents of the file
                byte[] fileContents = new byte[inStream.Length];
                //Read the contents to this byte array
                inStream.Read(fileContents, 0, fileContents.Length);
                zipStream.Write(fileContents, 0, fileContents.Length);

                //Now close all the streams.
                zipStream.Close();
                inStream.Close();
                outStream.Close();
            }
        }
    }
}
