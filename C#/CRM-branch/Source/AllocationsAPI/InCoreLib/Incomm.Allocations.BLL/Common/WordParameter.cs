using System.IO;

namespace Incomm.Allocations.BLL.Common
{
    public class WordParameter
    {
        #region Name
        /// <summary>
        /// Gets or sets the Name of this WordParameter.
        /// </summary>
        public string Name { get; set; }
        #endregion


        #region Text
        /// <summary>
        /// Gets or sets the Text of this WordParameter.
        /// </summary>
        public string Text { get; set; }
        #endregion


        #region Image
        /// <summary>
        /// Gets or sets the Image of this WordParameter.
        /// </summary>
        public FileInfo Image { get; set; }
        #endregion

    }
}
