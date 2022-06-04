using NAudio.Wave; //剪辑音频
//using Shell32; //获取音频时长
using System;
using System.Diagnostics;
using System.IO;

namespace 音频剪辑
{
    public partial class 主窗口 : Form
    {
        public 主窗口()
        {
            InitializeComponent();
        }

        private void 按钮_打开音频文件_点击(object sender, EventArgs e)
        {
            输入框_音频文件.Text = 打开文件对话框("wav");
        }

        private void 按钮_打开字幕文件_点击(object sender, EventArgs e)
        {
            输入框_字幕文件.Text = 打开文件对话框("srt");
        }
        private string 打开文件对话框(string type)
        {
            string file = "";
            OpenFileDialog 文件打开对话框 = new OpenFileDialog();
            文件打开对话框.Multiselect = false;      //该值确定是否可以选择多个文件
            文件打开对话框.Title = "请选择文件";     //弹窗的标题
            文件打开对话框.InitialDirectory = "D:\\";       //默认打开的文件夹的位置
            文件打开对话框.Filter = "选择文件(*." + type + ")|*." + type;    //筛选文件
            文件打开对话框.ShowHelp = true;     //是否显示“帮助”按钮

            if (文件打开对话框.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = 文件打开对话框.FileName;
            }
            return file;
        }
        private string 保存文件对话框()
        {
            SaveFileDialog 文件保存对话框 = new SaveFileDialog();
            文件保存对话框.Filter = "所有文件 (*.wav)|*.wav";
            //文件保存对话框.Multiselect = false;

            return 文件保存对话框.FileName;
        }
        bool 是否解析 = false;
        private async void 按钮_开始剪辑_点击(object sender, EventArgs e)
        {
            if (是否解析==false)
            {
                按钮_解析字幕_点击(sender, e);
            }
            int 序号 = 0;
            try
            {
                序号 = int.Parse(输入框_开始序号.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("开始序号需要输入数字");
                return;
            }
            
            string 路径 = Path.GetDirectoryName(输入框_保存路径.Text);
            string 文件名 = Path.GetFileNameWithoutExtension(输入框_保存路径.Text);
            进度条_剪辑音频.Maximum = 解析字幕.Count + 1;
            进度条_剪辑音频.Value = 0;
            创建文件夹(路径 + "\\corpus\\train\\"+文件名);
            创建文件夹(路径 + "\\transcript");
            创建文件夹(路径 + "\\txt");
            using (StreamWriter 总文本 = new StreamWriter(路径 + "\\transcript\\" + "aidatatang_200_zh_transcript.txt"))
            {
                //把数据写入txt文本流
                foreach (var item in 解析字幕)
                {
                    TrimWavFile(输入框_音频文件.Text, 路径 + "\\corpus\\train\\" + 文件名 + "\\" + 文件名 + 序号.ToString() + ".wav", item.开始时间, item.结束时间);
                    using (StreamWriter 单个文本 = new StreamWriter(路径 + "\\txt\\" + 文件名 + 序号.ToString() + ".txt"))
                    {
                        //把数据写入txt文本流
                        await 单个文本.WriteLineAsync(item.文字内容);
                        await 总文本.WriteLineAsync(文件名 + 序号.ToString() + " " + item.文字内容);
                        单个文本.Close();
                    }


                    序号++;
                    进度条_剪辑音频.Value++;
                }
                总文本.Close();
                进度条_剪辑音频.Value++;
            }
            MessageBox.Show("写入完成");
        }
        /// <summary>
        /// 基于NAudio工具对Wav音频文件剪切（限PCM格式）
        /// </summary>
        /// <param name="inPath">目标文件</param>
        /// <param name="outPath">输出文件</param>
        /// <param name="cutFromStart">开始时间</param>
        /// <param name="cutFromEnd">结束时间</param>
        public static void TrimWavFile(string inPath, string outPath, TimeSpan cutFromStart, TimeSpan cutFromEnd)
        {
            using (WaveFileReader reader = new WaveFileReader(inPath))
            {
                int fileLength = (int)reader.Length; using (WaveFileWriter writer = new WaveFileWriter(outPath, reader.WaveFormat))
                {
                    float bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000f;
                    int startPos = (int)Math.Round(cutFromStart.TotalMilliseconds * bytesPerMillisecond);
                    startPos = startPos - startPos % reader.WaveFormat.BlockAlign;
                    int endPos = (int)Math.Round(cutFromEnd.TotalMilliseconds * bytesPerMillisecond);
                    endPos = endPos - endPos % reader.WaveFormat.BlockAlign;
                    //判断结束位置是否越界
                    endPos = endPos > fileLength ? fileLength : endPos;
                    TrimWavFile(reader, writer, startPos, endPos);
                   
                }
            }
        }
        /// <summary>
        /// 重新合并wav文件
        /// </summary>
        /// <param name="reader">读取流</param>
        /// <param name="writer">写入流</param>
        /// <param name="startPos">开始流</param>
        /// <param name="endPos">结束流</param>
        private static void TrimWavFile(WaveFileReader reader, WaveFileWriter writer, int startPos, int endPos)
        {
            reader.Position = startPos;
            byte[] buffer = new byte[1024];
            while (reader.Position < endPos)
            {
                int bytesRequired = (int)(endPos - reader.Position);
                if (bytesRequired > 0)
                {
                    int bytesToRead = Math.Min(bytesRequired, buffer.Length);
                    int bytesRead = reader.Read(buffer, 0, bytesToRead);
                    if (bytesRead > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        private void 按钮_选择保存路径_点击(object sender, EventArgs e)
        {
            输入框_保存路径.Text = 保存文件对话框();
        }
        
        class 剪辑段
        {
            public int 序号;
            public TimeSpan 开始时间;
            public TimeSpan 结束时间;
            public string 文字内容;
        }
        List<剪辑段> 解析字幕 = new List<剪辑段>();
        private void 按钮_解析字幕_点击(object sender, EventArgs e)
        {
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(输入框_字幕文件.Text))
                {
                    解析字幕.Clear();
                    string line;
                    int index = 0;
                    // 从文件读取并显示行，直到文件的末尾 
                    剪辑段 temp = new 剪辑段();
                    while (sr.Peek()>-1)
                    {
                        line = sr.ReadLine();
                        switch (index)
                        {
                            case 0:
                                temp = new 剪辑段();
                                int.TryParse(line, out temp.序号);
                                break;
                            case 1:
                                int 时, 分, 秒,毫秒;
                                int.TryParse(line.Substring(0,2), out 时);
                                int.TryParse(line.Substring(3, 2), out 分);
                                int.TryParse(line.Substring(6, 2), out 秒);
                                int.TryParse(line.Substring(9, 3), out 毫秒);
                                temp.开始时间 =  new TimeSpan(0, 时, 分, 秒, 毫秒);
                                int.TryParse(line.Substring(17+0, 2), out 时);
                                int.TryParse(line.Substring(17+3, 2), out 分);
                                int.TryParse(line.Substring(17+6, 2), out 秒);
                                int.TryParse(line.Substring(17+9, 3), out 毫秒);
                                temp.结束时间 = new TimeSpan(0, 时, 分, 秒, 毫秒);
                                break;
                            case 2:
                                temp.文字内容 = line.Trim();
                                break;
                            case 3:
                                解析字幕.Add(temp);
                                break;
                            default:
                                break;
                        }
                        if (index<3)
                        {
                            index++;
                        }
                        else
                        {
                            index = 0;
                        }
                        
                    }
                }
            }
            catch (Exception)
            { 
                MessageBox.Show("打开文件错误");
            }
            显示框_信息显示.Text = "";
            显示框_信息显示.Hide();
            foreach (var item in 解析字幕)
            {
                
                显示框_信息显示.AppendText(
                    item.序号.ToString()
                    + "\t"
                    + item.开始时间.ToString()
                    + "\t>>\t"
                    + item.结束时间.ToString()
                    + ":\t"
                    + item.文字内容
                    +"\r\n"
                    );
            }
            显示框_信息显示.Show();
            是否解析 = true;
        }


        private void 创建文件夹(string subPath)
        {
            if (false == Directory.Exists(subPath))
            {
                //创建文件夹
                Directory.CreateDirectory(subPath);
            }
        }
        
        private async void 按钮_重命名_点击(object sender, EventArgs e)
        {
            string 重命名目录 = "";
            FolderBrowserDialog 保存位置 = new FolderBrowserDialog();
            保存位置.Description = "请选择保存位置";
            if (保存位置.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(保存位置.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                重命名目录 = 保存位置.SelectedPath;

            }

            DirectoryInfo caseDirInfo = new DirectoryInfo(重命名目录);
            //caseDirInfo.GetFiles(".", SearchOption.AllDirectories);//获取文件夹下所有文件包含子文件夹
            var 文件列表 = caseDirInfo.GetDirectories();//获取当前目录文件夹下文件
            创建文件夹(重命名目录 + "\\..\\0输出");
            进度条_重命名总进度.Maximum = 文件列表.Length;
            进度条_重命名总进度.Value = 0;
            foreach (var item in 文件列表)
            {
                string source = item.FullName+ "\\vocals.wav";//源文件路径
                string target = 重命名目录 + "\\..\\0输出\\" + item.Name+".wav";//目标文件路径
                float percent = 0;//控制台输出拷贝进度，百分比格式
                //CopyFile(source, target, ref percent);//调用拷贝文件的方法
                int bufferSize = 1024 * 1024 * 10;
                byte[] array = new byte[bufferSize]; //创建缓冲区
                using (FileStream fsRead = File.Open(source, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fsWrite = File.Open(target, FileMode.Create, FileAccess.Write))
                    {
                        进度条_复制文件.Maximum = (int)fsRead.Length;
                        进度条_复制文件.Value = 0;
                        while (fsRead.Position < fsRead.Length)
                        {
                            //读取到文件缓冲区
                            int length = await fsRead.ReadAsync(array, 0, array.Length);
                            //从缓冲区写到新文件
                            await fsWrite.WriteAsync(array, 0, length);
                            //计算进度
                            进度条_复制文件.Value += length;
                        }
                        fsWrite.Close();
                    }
                    fsRead.Close();
                }
                进度条_重命名总进度.Value++;
            }

            if (string.IsNullOrEmpty(重命名目录 + "\\..\\0输出")) return;

            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("Explorer.exe");
            psi.Arguments = 重命名目录 + "\\..\\0输出";
            process.StartInfo = psi;
            MessageBox.Show("保存完成！路径为:"+ 重命名目录 + "\\..\\0输出"+"\n现在为你打开路径");
            try
            {
                process.Start();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                process?.Close();

            }
            


        }
    }
}