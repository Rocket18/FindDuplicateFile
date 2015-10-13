using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Data;
using System.Runtime.InteropServices;



namespace DuplicateFile.BL
{
    public interface IFileManager
    {
        bool IsExists(string path);
        void getFs(string Dir, string[] extension, long? minSize, long? MaxSize);
        DataTable GenerateResult(int a);
        void DeleteFile(string name);
        bool ShowFileProperties(string Filename);
        List<string> Algorithm();
        void FindDublicate(int algorithm);
        void DeleteDuplicateFile();
    }




    public class FileManager : IFileManager
    {
        private Stopwatch timeRun;
        FileInfo[] fileInfo;
        List<Tuple<string, FileInfo>> result;//Кінцевий результат
        private int groupBinaryCount = 1;
        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        public bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }
        public FileManager()
        {
            timeRun = new Stopwatch();
            
            result = new List<Tuple<string, FileInfo>>();
        }
        public List<string> Algorithm()
        {

            // Dictionary<int, string> res = new Dictionary<int, string>();
            var res = new List<string>()
            {
               "Побайтово","MD5","CRC-32"
            };
            return res;

        }

        public void DeleteFile(string name)
        {

            if (Directory.Exists(Path.GetDirectoryName(name)))
            {
                File.Delete(name);
                result.RemoveAll(f => f.Item2.FullName == name);
            }



        }
        public void DeleteDuplicateFile()
        {
            var printGroup = result.GroupBy(t => t.Item1).Where(group => group.Count() > 1);
            foreach (var group in printGroup)
            {

                if (group.Count() > 1)
                    DeleteProcces(group);
            }
        }
        public bool IsExists(string path)
        {
            return (Directory.Exists(path)) ? true : false;
        }

        void DeleteProcces(IEnumerable<Tuple<string, FileInfo>> file)
        {
            bool first = false;
            foreach (var a in file)
            {
                if (first)
                    DeleteFile(a.Item2.FullName);

                first = true;
            }
        }

        public void getFs(string Dir, string[] extensions, long? minSize, long? maxSize)
        {

            fileInfo = new DirectoryInfo(Dir).GetFiles("*.*", SearchOption.AllDirectories);
            bool all = false;
            if (extensions.Count() == 1 && String.Compare(extensions[0], "*.*", StringComparison.Ordinal) == 0)
                all = true;

            if (!all)
            {
                fileInfo = fileInfo.Where(f => extensions.Contains(f.Extension.ToUpper())).ToArray();
            }
           

           


            if (minSize != null && maxSize != null)
            {
                fileInfo = new DirectoryInfo(Dir).GetFiles("*.*", SearchOption.AllDirectories)
                                                   .Where(s => (s.Length >= minSize && s.Length <= maxSize && extensions.Contains(s.Extension.ToUpper()))).ToArray();

            }

            if (minSize != null && maxSize == null)
            {
                fileInfo = new DirectoryInfo(Dir).GetFiles("*.*", SearchOption.AllDirectories)
                   .Where(s => (s.Length >= minSize && extensions.Contains(s.Extension.ToUpper()))).ToArray();

            }

            if (minSize == null && maxSize != null)
            {
                fileInfo = new DirectoryInfo(Dir).GetFiles("*.*", SearchOption.AllDirectories)
                   .Where(s => (s.Length <= maxSize && extensions.Contains(s.Extension.ToUpper()))).ToArray();

            }
        }

        public void FindDublicate(int algorithm)
        {

            result.Clear();
            var duplicateGroups = fileInfo.GroupBy(file => file.Length)
                                              .Where(group => group.Count() > 1);


            switch (algorithm)
            {

                case 0:
                    groupBinaryCount = 1;
                    foreach (var group in duplicateGroups)
                    {

                        BitCompare(group);
                    }
                    break;
                case 1:
                    foreach (var group in duplicateGroups)
                    {
                        Md5Compare(group);
                    }
                    break;
                case 2:
                    foreach (var group in duplicateGroups)
                    {
                        CrcCompare(group);
                    }
                    break;
            }
        }

        public DataTable GenerateResult(int algorithm)
        {
            var printGroup = result.GroupBy(t => t.Item1).Where(group => group.Count() > 1);
            var data = new DataTable();
            data.Columns.Add("Назва файлу", typeof(String));
            data.Columns.Add("Шляху", typeof(String));
            data.Columns.Add("Група", typeof(String));
            data.Columns.Add("Розмір(байт)", typeof(long));

            if (algorithm == 0)
            {
                foreach (var group in printGroup)
                {

                    foreach (var file in group)
                    {

                        data.Rows.Add(file.Item2.Name, file.Item2.FullName, file.Item1, file.Item2.Length);
                    }

                }
            }
            else
            {
                groupBinaryCount = 1;
                foreach (var group in printGroup)
                {

                    foreach (var file in group)
                    {

                        data.Rows.Add(file.Item2.Name, file.Item2.FullName, groupBinaryCount, file.Item2.Length);
                    }
                    groupBinaryCount++;
                }
            }
            return data;
        }
        private void BitCompare(IEnumerable<FileInfo> group)
        {

            var temp = new List<Tuple<string, FileInfo>>();
            foreach (var file in group)
            {
                temp.Add(Tuple.Create(file.FullName, file));
            }
            Comparebits(temp);
        }
        private void Md5Compare(IEnumerable<FileInfo> group)
        {
            foreach (var file in group)
            {
                FileStream stream1 = File.OpenRead(file.FullName);
                result.Add(Tuple.Create(ComputeMD5Checksum(file.FullName), file));
            }
        }
        private void CrcCompare(IEnumerable<FileInfo> group)
        {
            foreach (var file in group)
            {
                FileStream stream1 = File.OpenRead(file.FullName);
                result.Add(Tuple.Create(String.Format("{0:X}", CalculateCRC(stream1)), file));
            }
        }

        #region Побайтову порівняння
        private void Comparebits(List<Tuple<string, FileInfo>> temp)
        {
            while (temp.Count() >= 2)
            {
                bool first = false;
                var info = new FileInfo(temp[0].Item1);
                int i = 1;
                int count = temp.Count();

                for (; i < count; i++)
                {
                    var info2 = new FileInfo(temp[i].Item1);
                    if (FilesContentsAreEqual(info, info2))
                    {
                        result.Add(Tuple.Create(groupBinaryCount.ToString(), temp[i].Item2));
                        temp.RemoveAt(i);
                        first = true;
                        i--;
                        count--;
                    }
                }

                if (first)
                {
                    result.Add(Tuple.Create(groupBinaryCount.ToString(), temp[0].Item2));
                    groupBinaryCount++;
                }
                else
                {
                    temp.RemoveAt(0);
                }
            }
        }

        private bool FilesContentsAreEqual(FileInfo fileInfo1, FileInfo fileInfo2)
        {
            using (var file1 = fileInfo1.OpenRead())
            {
                using (var file2 = fileInfo2.OpenRead())
                {
                    return StreamsContentsAreEqual(file1, file2);
                }
            }
        }

        private bool StreamsContentsAreEqual(Stream stream1, Stream stream2)
        {
            const int bufferSize = 2048 * 2;

            var buffer1 = new byte[bufferSize];
            var buffer2 = new byte[bufferSize];

            while (true)
            {
                int count1 = stream1.Read(buffer1, 0, bufferSize);
                int count2 = stream2.Read(buffer2, 0, bufferSize);

                if (count1 != count2)
                {
                    return false;
                }

                if (count1 == 0)
                {
                    return true;
                }

                int iterations = (int)Math.Ceiling((double)count1 / sizeof(Int64));

                for (int i = 0; i < iterations; i++)
                {
                    if (BitConverter.ToInt64(buffer1, i * sizeof(Int64)) != BitConverter.ToInt64(buffer2, i * sizeof(Int64)))
                    {
                        return false;
                    }
                }
            }
        }
        #endregion
        #region MD5
        private string ComputeMD5Checksum(string path)
        {
            using (var fs = new BufferedStream(File.OpenRead(path), 8388608))// using (var stream = new BufferedStream(File.OpenRead(path), 8388608))//1 MB
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] checkSum = md5.ComputeHash(fs);
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
            }
        }
        #endregion
        #region CRC32
        private uint CalculateCRC(Stream stream)
        {
            const int buffer_size = 1024;
            const uint POLYNOMIAL = 0xEDB88320;

            uint result = 0xFFFFFFFF;
            uint Crc32;

            byte[] buffer = new byte[buffer_size];
            uint[] table_CRC32 = new uint[256];

            unchecked
            {
                for (int i = 0; i < 256; i++)
                {
                    Crc32 = (uint)i;

                    for (int j = 8; j > 0; j--)
                    {
                        if ((Crc32 & 1) == 1)
                        {
                            Crc32 = (Crc32 >> 1) ^ POLYNOMIAL;
                        }
                        else
                        {
                            Crc32 >>= 1;
                        }
                    }

                    table_CRC32[i] = Crc32;
                }

                //
                // Читання з буферу
                //
                int count = stream.Read(buffer, 0, buffer_size);

                //
                // Обрахування CRC
                //
                while (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        result = ((result) >> 8)
                            ^ table_CRC32[(buffer[i])
                            ^ ((result) & 0x000000FF)];
                    }

                    count = stream.Read(buffer, 0, buffer_size);
                }
            }
            return ~result;
        }
        #endregion

    }
}
