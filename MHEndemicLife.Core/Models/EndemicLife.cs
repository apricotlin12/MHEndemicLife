using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHEndemicLife.Core.Models
{
    public class EndemicLife
    {
        public int EndemicLife_Id { get; set; } // 主鍵，自動流水號
        public required string EndemicLife_Name { get; set; } // 名稱
        public required string EndemicLife_Environment { get; set; } // 出現環境
        public string? EndemicLife_Area { get; set; } // 出現區域，可空
        public string? EndemicLife_Season { get; set; } // 季節，可空
        public string? EndemicLife_Time { get; set; } // 時間，可空
        public string? EndemicLife_Notes { get; set; } // 備註，可空
    }
}
