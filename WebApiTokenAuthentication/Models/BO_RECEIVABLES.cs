using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiTokenAuthentication.Models
{
    public sealed class BO_RECEIVABLES
    {

        #region Properties

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TRAN_ID { get; set; } = string.Empty;
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TRAN_TYPE { get; set; } = string.Empty;
        [Key, Column(Order = 2), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RECEIVABLES_ID { get; set; } = string.Empty;
        [Key, Column(Order = 3), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PART_SRL_ID { get; set; } = string.Empty;
        public string CHANGE_FLG { get; set; } = string.Empty;
        public DateTime CHANGE_DT { get; set; } = new DateTime(1900, 1, 1);
        public string CHANGE_DT_STR { get; set; } = string.Empty;
        public DateTime REQ_DT { get; set; } = new DateTime(1900, 1, 1);
        public string REQ_DT_STR { get; set; } = string.Empty;
        public DateTime REQ_RECEIVABLES_DT { get; set; } = new DateTime(1900, 1, 1);
        public DateTime RECEIVABLES_DT { get; set; } = new DateTime(1900, 1, 1);
        public string RECEIVABLES_DT_STR { get; set; } = string.Empty;
        public string TRAN_CAT_ID { get; set; } = string.Empty;
        public string TRAN_CAT_NAME { get; set; } = string.Empty;
        public string TRAN_SUB_CAT_ID { get; set; } = string.Empty;
        public string TRAN_SUB_CAT_NAME { get; set; } = string.Empty;
        public string TRAN_ITEM_ID { get; set; } = string.Empty;
        public string TRAN_ITEM_NAME { get; set; } = string.Empty;
        public decimal RECEIVABLES_AMT_LCY { get; set; }
        public decimal RECEIVABLES_AMT_FCY { get; set; }
        public decimal RECEIVABLES_AMT_VCY { get; set; }
        public string RECEIVABLES_AMT_CCY { get; set; } = string.Empty;
        public string RCPT_STATUS_FLG { get; set; } = string.Empty;
        public string REF_PYMT_VOUCHER_ID { get; set; } = string.Empty;
        public decimal RCPT_AMT_LCY { get; set; }
        public decimal RCPT_AMT_FCY { get; set; }
        public decimal RCPT_AMT_VCY { get; set; }
        public string RCPT_AMT_CCY { get; set; } = string.Empty;
        public decimal OUTSTAND_AMT_LCY { get; set; }
        public decimal OUTSTAND_AMT_FCY { get; set; }
        public decimal OUTSTAND_AMT_VCY { get; set; }
        public string OUTSTAND_AMT_CCY { get; set; } = string.Empty;
        public string PAYABLE_TYPE { get; set; } = string.Empty;
        public string TRAN_INSTR_TYPE { get; set; } = string.Empty;
        public string TRAN_INSTR_ID { get; set; } = string.Empty;
        public string TRAN_P_ODER_ID { get; set; } = string.Empty;
        public string TRAN_P_ODER_NO { get; set; } = string.Empty;
        public string TRAN_S_ODER_ID { get; set; } = string.Empty;
        public string TRAN_S_ODER_NO { get; set; } = string.Empty;
        public string TRAN_PC_INVOICE_ID { get; set; } = string.Empty;
        public string TRAN_PC_INVOICE_NO { get; set; } = string.Empty;
        public string TRAN_SC_INVOICE_ID { get; set; } = string.Empty;
        public string TRAN_SC_INVOICE_NO { get; set; } = string.Empty;
        public string TRAN_PP_INVOICE_ID { get; set; } = string.Empty;
        public string TRAN_PP_INVOICE_NO { get; set; } = string.Empty;
        public string TRAN_SP_INVOICE_ID { get; set; } = string.Empty;
        public string TRAN_SP_INVOICE_NO { get; set; } = string.Empty;
        public string TRAN_I_BOE_ID { get; set; } = string.Empty;
        public string TRAN_I_BOE_NO { get; set; } = string.Empty;
        public string TRAN_O_BOE_ID { get; set; } = string.Empty;
        public string TRAN_O_BOE_NO { get; set; } = string.Empty;
        public string TRAN_PC_INVOICE_ITEM_ID { get; set; } = string.Empty;
        public string TRAN_PC_INVOICE_ITEM_NO { get; set; } = string.Empty;
        public decimal SHIP_VCY_RATE { get; set; }
        public decimal SHIP_LCY_RATE { get; set; }
        public decimal SHIP_WASH_RATE { get; set; }
        public DateTime SHIP_DT { get; set; } = new DateTime(1900, 1, 1);
        public string INT_TYPE { get; set; } = string.Empty;
        public decimal INT_RATE { get; set; }
        public DateTime INT_REPRICE_DT { get; set; } = new DateTime(1900, 1, 1);
        public string RCPT_PARTY { get; set; } = string.Empty;
        public string RCPT_PARTY_NAME { get; set; } = string.Empty;
        public string RCPT_PRJ { get; set; } = string.Empty;
        public string RCPT_PRJ_NAME { get; set; } = string.Empty;
        public string EXPCT_RCPT_BANK { get; set; } = string.Empty;
        public string EXPCT_RCPT_BRANCH { get; set; } = string.Empty;
        public string PREF_SET_TYPE { get; set; } = string.Empty;
        public string EXPCT_RCPT_MODE { get; set; } = string.Empty;
        public string EXPCT_RCPT_INST_ID { get; set; } = string.Empty;
        public string PREF_CLEARING_BANK { get; set; } = string.Empty;
        public string PREF_CLEARING_BRANCH { get; set; } = string.Empty;
        public string PREF_CLEARING_ACID { get; set; } = string.Empty;
        public string INVST_TYPE { get; set; } = string.Empty;
        public string INVST_TYPE_ID { get; set; } = string.Empty;
        public string REALIZED_FLG { get; set; } = string.Empty;
        public decimal INVST_UNITS { get; set; }
        public decimal OUT_STANDING_UNITS { get; set; }
        public decimal REALIZED_AMT_LCY { get; set; }
        public decimal REALIZED_AMT_FCY { get; set; }
        public decimal REALIZED_AMT_VCY { get; set; }
        public string REALIZED_AMT_CCY { get; set; } = string.Empty;
        public DateTime LAST_REALIZED_DT { get; set; } = new DateTime(1900, 1, 1);
        public string LAST_REALIZED_DT_STR { get; set; } = string.Empty;
        public string PURPOSE { get; set; } = string.Empty;
        public string GEN_TYPE { get; set; } = string.Empty;
        public string REQ_BY { get; set; } = string.Empty;
        public string REQ_SUBSIDIARY_ID { get; set; } = string.Empty;
        public string REQ_DIV { get; set; } = string.Empty;
        public string REQ_SUB_DIV { get; set; } = string.Empty;
        public string DEL_FLG { get; set; } = string.Empty;
        public string MOD_ID { get; set; } = string.Empty;
        public DateTime MOD_TIME { get; set; } = new DateTime(1900, 1, 1);
        public string CRE_ID { get; set; } = string.Empty;
        public DateTime CRE_TIME { get; set; } = new DateTime(1900, 1, 1);
        public string CORP_BRANCH_ID { get; set; } = string.Empty;
        public decimal ACCOUNT_TRAN_ID { get; set; }
        public string FUND_NATURE_ID { get; set; } = string.Empty;
        public string VOUCHER_ISSUE_FLG { get; set; } = string.Empty;
        public string ADVNC_VOUCHER_INSTR_TYPE { get; set; } = string.Empty;
        public decimal ADVNC_VOUCHER_ISSUED_AMT_FCY { get; set; }
        public decimal ADVNC_VOUCHER_ISSUED_AMT_LCY { get; set; }
        public string ADVNC_VOUCHER_ISSUED_AMT_CCY { get; set; } = string.Empty;
        public string RCPT_PREF_SRC_FLG { get; set; } = string.Empty;
        public string INSTR_CPARTY { get; set; } = string.Empty;
        public string INSTR_CPARTY_NAME { get; set; } = string.Empty;
        public string AUTO_CREDIT_FLG { get; set; } = string.Empty;
        public string ADV_VOUCHER_RQST_FLAG { get; set; } = string.Empty;
        public DateTime EXPCT_ADV_VOUCHER_ISSUE_DT { get; set; } = new DateTime(1900, 1, 1);
        public string ADJ_ITEM_FLG { get; set; } = string.Empty;
        public string PROFORMA_VOUCHER_ID { get; set; } = string.Empty;
        public string INSTR_BENEFICIARY_ID { get; set; } = string.Empty;
        public string INSTR_BENEFICIARY_NAME { get; set; } = string.Empty;
        public string PROJECTED_CASHFLOW { get; set; } = string.Empty;
        public decimal SYS_RECEIVABLES_AMT_FCY { get; set; }
        public decimal SYS_RECEIVABLES_AMT_LCY { get; set; }
        public string SYS_RECEIVABLES_AMT_CCY { get; set; } = string.Empty;
        public string MANUAL_EDIT_ALLOWED { get; set; } = string.Empty;
        public string MODI_REMARKS { get; set; } = string.Empty;
        public DateTime TMP_CHANGE_DT { get; set; } = new DateTime(1900, 1, 1);
        public string ROOT_TRAN_ID { get; set; } = string.Empty;
        public string ROOT_TRAN_TYPE { get; set; } = string.Empty;
        public string ROOT_PAY_REC_ID { get; set; } = string.Empty;
        public string ROOT_PART_SRL_ID { get; set; } = string.Empty;
        public string PAY_REC { get; set; } = string.Empty;
        public decimal SPOT_REVAL_AMT_LCY { get; set; }
        public decimal FWD_REVAL_AMT_LCY { get; set; }
        public decimal SPOT_COVERED_REVAL_AMT_LCY { get; set; }
        public decimal FWD_COVERED_REVAL_AMT_LCY { get; set; }
        public decimal SHIP_VCY_SPOT_RATE { get; set; }
        public decimal SHIP_LCY_SPOT_RATE { get; set; }
        public decimal SHIP_WASH_SPOT_RATE { get; set; }
        public decimal SHIP_VCY_PREMIUM { get; set; }
        public decimal SHIP_LCY_PREMIUM { get; set; }
        public decimal SHIP_WASH_PREMIUM { get; set; }
        public decimal SHIP_VCY_MARGIN { get; set; }
        public decimal SHIP_LCY_MARGIN { get; set; }
        public decimal SHIP_WASH_MARGIN { get; set; }
        public decimal SPOT_REVAL_AMT_VCY { get; set; }
        public decimal FWD_REVAL_AMT_VCY { get; set; }
        public decimal SPOT_COVERED_REVAL_AMT_VCY { get; set; }
        public decimal FWD_COVERED_REVAL_AMT_VCY { get; set; }
        public string EXPCT_RCPT_ACID { get; set; } = string.Empty;


        #endregion
    }
}