using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Pmx;

namespace SelectVertexInput
{
    public class SelectVertexInput : PEPluginClass
    {
        public SelectVertexInput() : base()
        {
        }

        public override string Name
        {
            get
            {
                return "選択頂点の入力";
            }
        }

        public override string Version
        {
            get
            {
                return "1.0";
            }
        }

        public override string Description
        {
            get
            {
                return "選択頂点をテキストファイルから入力する";
            }
        }

        public override IPEPluginOption Option
        {
            get
            {
                // boot時実行, プラグインメニューへの登録, メニュー登録名
                return new PEPluginOption(false, true, "選択頂点の入力");
            }
        }

        public override void Run(IPERunArgs args)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
                ofd.Title = "ファイルの選択";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    args.Host.Connector.View.PmxView.SetSelectedVertexIndices(File.ReadLines(ofd.FileName).Select(str=>int.Parse(str)).ToArray());
                    MessageBox.Show("完了");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
