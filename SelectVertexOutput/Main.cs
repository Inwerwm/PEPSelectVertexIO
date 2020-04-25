using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Pmx;

namespace SelectVertexOutput
{
    public class SelectVertexOutput : PEPluginClass
    {
        public SelectVertexOutput() : base()
        {
        }

        public override string Name
        {
            get
            {
                return "選択頂点の出力";
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
                return "選択頂点をテキストファイルに出力する";
            }
        }

        public override IPEPluginOption Option
        {
            get
            {
                // boot時実行, プラグインメニューへの登録, メニュー登録名
                return new PEPluginOption(false, true, "選択頂点の出力");
            }
        }

        public override void Run(IPERunArgs args)
        {
            try
            {
                using(var writer = new StreamWriter($"SelectedVertex_{DateTime.Now:yyyyMMddHHmmss}.txt", false))
                {
                    foreach (var i in args.Host.Connector.View.PmxView.GetSelectedVertexIndices())
                    {
                        writer.WriteLine(i);
                    }
                }
                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
