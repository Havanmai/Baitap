using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class Enumeration
    {
        /// <summary>
        /// Hàm chuyển dữ liệu giới tính
        /// author: HVM(20/10/2020)
        /// </summary>
        public enum GenderEnum
        {
            /// <summary>
            /// nữ
            /// </summary>
            Female = 0,
            /// <summary>
            /// Nam
            /// </summary>
            Male = 1,
            /// <summary>
            /// Khác
            /// </summary>
            Other = 2
        }
        /// <summary>
        /// Hàm chuyển dữ liệu tình trạng công việc
        /// author: HVM(20/10/2020)
        /// </summary>
        public enum WorkStatus
        {
            /// <summary>
            /// Đã nghỉ việc
            /// </summary>
            Stopped = 0,

            /// <summary>
            /// Đang làm việc
            /// </summary>
            Working = 1,

            /// <summary>
            /// Đang thử việc
            /// </summary>
            Waiting = 2
        }

    }
}
