using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTokenAuthentication
{
    //[Serializable]

    // Remove serialize bcz not supporting in api
    public sealed class APIVoucherUpdateControls
    {
        #region Properties

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string documentnumber { get; set; } = string.Empty;

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string invoicenumber { get; set; } = string.Empty;

        public string transdate { get; set; } = string.Empty;
        public string documentdate { get; set; } = string.Empty;
        public decimal creditamount { get; set; }
        public decimal debitamount { get; set; }
        public string text { get; set; } = string.Empty;
        public string currency { get; set; } = string.Empty;
        public string duedate { get; set; } = string.Empty;
        public decimal postedcreditamount { get; set; }
        public decimal posteddebitamount { get; set; }
        public string postingnumber { get; set; } = string.Empty;
        public string postingbankaccount { get; set; } = string.Empty;
        public string IsDataValid { get; set; } = "N";
        public string VoucherStatus { get; set; } = "N";
        public string PAYorREC { get; set; } = string.Empty;
        public string PayablesID_ReceivablesID { get; set; } = string.Empty;
        public string PartSrlNo { get; set; } = string.Empty;
        public string TranID { get; set; } = string.Empty;
        public string TranType { get; set; } = string.Empty;

        #endregion Properties
    }
}