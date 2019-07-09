Imports System.Data.OleDb
Public Class Exportacion
    Dim dt As New DataTable
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function exportarData(External_id As Decimal, Patient_id As Decimal, Test_type As String, pp_Load As Decimal, pp_Increase_of_Load As Decimal, pp_Training_Duration As Decimal, pp_Training_HR As Decimal,
                                 pp_Relative_Decrease_of_Load As Decimal, pp_Alarm_Limit As Decimal, pp_Load_limit As Decimal, pp_NIBP As Decimal, pi_Load As Decimal, pi_Increase_of_Load As Decimal,
                                 pi_Training_Duration As Decimal, pi_Training_HR As Decimal, pi_Relative_Decrease_of_Load As Decimal, pi_Min_Time As Decimal, pi_Time_Lower_Level As Decimal,
                                 pi_Alarm_Limit As Decimal, pi_Load_limit As Decimal, pi_NIBP As Decimal, pr_Load As Decimal, pr_Increase_of_Load As Decimal, pr_Training_Duration As Decimal,
                                 pr_Training_HR As Decimal, pr_Relative_Decrease_of_Load As Decimal, pr_Time_for_Decrease As Decimal, pr_Increase As Decimal, pr_Alarm_Limit As Decimal,
                                 pr_Load_limit As Decimal, pr_NIBP As Decimal, lc_Load As Decimal, lc_Increase_of_Load As Decimal, lc_Training_Duration As Decimal, lc_Training_Load As Decimal,
                                 lc_Relative_Decrease_of_Load As Decimal, lc_Alarm_Limit As Decimal, lc_Load_limit As Decimal, lc_NIBP As Decimal, li_Load As Decimal, li_Increase_of_Load As Decimal,
                                 li_Training_Duration As Decimal, li_Upper_Level As Decimal, li_Relative_Decrease_of_Load As Decimal, li_Min_Time_Upper As Decimal, li_Min_Time_Lower As Decimal,
                                 li_Alarm_Limit As Decimal, li_Load_limit As Decimal, li_NIBP As Decimal, lr_Load As Decimal, lr_Increase_of_Load As Decimal, lr_Training_Duration As Decimal,
                                 lr_Upper_Level As Decimal, lr_Relative_Decrease_of_Load As Decimal, lr_Time_for_Decrease As Decimal, lr_Increase As Decimal, lr_Alarm_Limit As Decimal,
                                 lr_Load_limit As Decimal, lr_NIBP As Decimal, lf_Alarm_Limit As Decimal, lf_NIBP As Decimal, tt_w1_speed_m As Decimal, tt_w1_speed_km As Decimal,
                                 tt_w_slope As Decimal, tt_w2_speed_m As Decimal, tt_w2_speed_km As Decimal, tt_Increase_of_slope As Decimal, tt_Training_Duration As Decimal, tt_tr_speed_m As Decimal,
                                 tt_tr_speed_km As Decimal, tt_Distance As Decimal, tt_tr_slope As Decimal, tt_Alarm_Limit As Decimal, tt_NIBP As Decimal, tp_w1_speed_m As Decimal, tp_w1_speed_km As Decimal,
                                 tp_w_slope As Decimal, tp_w2_speed_m As Decimal, tp_w2_speed_km As Decimal, tp_Increase_of_slope As Decimal, tp_Training_Duration As Decimal, tp_tr_speed_m As Decimal,
                                 tp_tr_speed_km As Decimal, tp_HR_Min As Decimal, tp_HR_Max As Decimal, tp_Alarm_Limit As Decimal, tp_NIBP As Decimal, IPN_gender As Decimal, IPN_Wt As String, IPN_Age As String,
                                 IPN_Resting_HR As String, IPN_Option As Decimal, IPN_Target_HR As String, IPN_Protocol As Decimal, Free_def As String, Fecg_Training_Duration As Decimal, Fecg_Alarm_Limit As Decimal,
                                 Fecg_NIBP As Decimal, Alarm_NIBP As String, Alarm_SPO2 As String) As Boolean
        Dim conn As OleDbConnection = New OleDbConnection("Provider=SQLOLEDB;Server=173.248.151.67,1533;Database=Kapland;User Id=kapland;Password=Kaplan*2018;")
        Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.kaplan.RegistrarDataAccess", conn)
        cmd.CommandType = CommandType.StoredProcedure
#Region "Parámetros"
        Dim inExternal_id As OleDbParameter = cmd.Parameters.Add("@External_id", OleDbType.Decimal, Nothing)
        inExternal_id.Direction = ParameterDirection.Input
        inExternal_id.Value = External_id
        Dim inPatient_id As OleDbParameter = cmd.Parameters.Add("@Patient_id", OleDbType.Decimal, Nothing)
        inPatient_id.Direction = ParameterDirection.Input
        inPatient_id.Value = Patient_id
        Dim inTest_type As OleDbParameter = cmd.Parameters.Add("@Test_type", OleDbType.VarChar, 100)
        inTest_type.Direction = ParameterDirection.Input
        inTest_type.Value = Test_type
        Dim inpp_Load As OleDbParameter = cmd.Parameters.Add("@pp_Load", OleDbType.Decimal, Nothing)
        inpp_Load.Direction = ParameterDirection.Input
        inpp_Load.Value = pp_Load
        Dim inpp_Increase_of_Load As OleDbParameter = cmd.Parameters.Add("@pp_Increase_of_Load", OleDbType.Decimal, Nothing)
        inpp_Increase_of_Load.Direction = ParameterDirection.Input
        inpp_Increase_of_Load.Value = pp_Increase_of_Load
        Dim inpp_Training_Duration As OleDbParameter = cmd.Parameters.Add("@pp_Training_Duration", OleDbType.Decimal, Nothing)
        inpp_Training_Duration.Direction = ParameterDirection.Input
        inpp_Training_Duration.Value = pp_Training_Duration
        Dim inpp_Training_HR As OleDbParameter = cmd.Parameters.Add("@pp_Training_HR", OleDbType.Decimal, Nothing)
        inpp_Training_HR.Direction = ParameterDirection.Input
        inpp_Training_HR.Value = pp_Training_HR
        Dim inpp_Relative_Decrease_of_Load As OleDbParameter = cmd.Parameters.Add("@pp_Relative_Decrease_of_Load", OleDbType.Decimal, Nothing)
        inpp_Relative_Decrease_of_Load.Direction = ParameterDirection.Input
        inpp_Relative_Decrease_of_Load.Value = pp_Relative_Decrease_of_Load
        Dim inpp_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@pp_Alarm_Limit", OleDbType.Decimal, Nothing)
        inpp_Alarm_Limit.Direction = ParameterDirection.Input
        inpp_Alarm_Limit.Value = pp_Alarm_Limit
        Dim inpp_Load_limit As OleDbParameter = cmd.Parameters.Add("@pp_Load_limit", OleDbType.Decimal, Nothing)
        inpp_Load_limit.Direction = ParameterDirection.Input
        inpp_Load_limit.Value = pp_Load_limit
        Dim inpp_NIBP As OleDbParameter = cmd.Parameters.Add("@pp_NIBP", OleDbType.Decimal, Nothing)
        inpp_NIBP.Direction = ParameterDirection.Input
        inpp_NIBP.Value = pp_NIBP
        Dim inpi_Load As OleDbParameter = cmd.Parameters.Add("@pi_Load", OleDbType.Decimal, Nothing)
        inpi_Load.Direction = ParameterDirection.Input
        inpi_Load.Value = pi_Load
        Dim inpi_Increase_of_Load As OleDbParameter = cmd.Parameters.Add("@pi_Increase_of_Load", OleDbType.Decimal, Nothing)
        inpi_Increase_of_Load.Direction = ParameterDirection.Input
        inpi_Increase_of_Load.Value = pi_Increase_of_Load
        Dim inpi_Training_Duration As OleDbParameter = cmd.Parameters.Add("@pi_Training_Duration", OleDbType.Decimal, Nothing)
        inpi_Training_Duration.Direction = ParameterDirection.Input
        inpi_Training_Duration.Value = pi_Training_Duration
        Dim inpi_Training_HR As OleDbParameter = cmd.Parameters.Add("@pi_Training_HR", OleDbType.Decimal, Nothing)
        inpi_Training_HR.Direction = ParameterDirection.Input
        inpi_Training_HR.Value = pi_Training_HR
        Dim inpi_Relative_Decrease_of_Load As OleDbParameter = cmd.Parameters.Add("@pi_Relative_Decrease_of_Load", OleDbType.Decimal, Nothing)
        inpi_Relative_Decrease_of_Load.Direction = ParameterDirection.Input
        inpi_Relative_Decrease_of_Load.Value = pi_Relative_Decrease_of_Load
        Dim inpi_Min_Time As OleDbParameter = cmd.Parameters.Add("@pi_Min_Time", OleDbType.Decimal, Nothing)
        inpi_Min_Time.Direction = ParameterDirection.Input
        inpi_Min_Time.Value = pi_Min_Time
        Dim inpi_Time_Lower_Level As OleDbParameter = cmd.Parameters.Add("@pi_Time_Lower_Level", OleDbType.Decimal, Nothing)
        inpi_Time_Lower_Level.Direction = ParameterDirection.Input
        inpi_Time_Lower_Level.Value = pi_Time_Lower_Level
        Dim inpi_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@pi_Alarm_Limit", OleDbType.Decimal, Nothing)
        inpi_Alarm_Limit.Direction = ParameterDirection.Input
        inpi_Alarm_Limit.Value = pi_Alarm_Limit
        Dim inpi_Load_limit As OleDbParameter = cmd.Parameters.Add("@pi_Load_limit", OleDbType.Decimal, Nothing)
        inpi_Load_limit.Direction = ParameterDirection.Input
        inpi_Load_limit.Value = pi_Load_limit
        Dim inpi_NIBP As OleDbParameter = cmd.Parameters.Add("@pi_NIBP", OleDbType.Decimal, Nothing)
        inpi_NIBP.Direction = ParameterDirection.Input
        inpi_NIBP.Value = pi_NIBP
        Dim inpr_Load As OleDbParameter = cmd.Parameters.Add("@pr_Load", OleDbType.Decimal, Nothing)
        inpr_Load.Direction = ParameterDirection.Input
        inpr_Load.Value = pr_Load
        Dim inpr_Increase_of_Load As OleDbParameter = cmd.Parameters.Add("@pr_Increase_of_Load", OleDbType.Decimal, Nothing)
        inpr_Increase_of_Load.Direction = ParameterDirection.Input
        inpr_Increase_of_Load.Value = pr_Increase_of_Load
        Dim inpr_Training_Duration As OleDbParameter = cmd.Parameters.Add("@pr_Training_Duration", OleDbType.Decimal, Nothing)
        inpr_Training_Duration.Direction = ParameterDirection.Input
        inpr_Training_Duration.Value = pr_Training_Duration
        Dim inpr_Training_HR As OleDbParameter = cmd.Parameters.Add("@pr_Training_HR", OleDbType.Decimal, Nothing)
        inpr_Training_HR.Direction = ParameterDirection.Input
        inpr_Training_HR.Value = pr_Training_HR
        Dim inpr_Relative_Decrease_of_Load As OleDbParameter = cmd.Parameters.Add("@pr_Relative_Decrease_of_Load", OleDbType.Decimal, Nothing)
        inpr_Relative_Decrease_of_Load.Direction = ParameterDirection.Input
        inpr_Relative_Decrease_of_Load.Value = pr_Relative_Decrease_of_Load
        Dim inpr_Time_for_Decrease As OleDbParameter = cmd.Parameters.Add("@pr_Time_for_Decrease", OleDbType.Decimal, Nothing)
        inpr_Time_for_Decrease.Direction = ParameterDirection.Input
        inpr_Time_for_Decrease.Value = pr_Time_for_Decrease
        Dim inpr_Increase As OleDbParameter = cmd.Parameters.Add("@pr_Increase", OleDbType.Decimal, Nothing)
        inpr_Increase.Direction = ParameterDirection.Input
        inpr_Increase.Value = pr_Increase
        Dim inpr_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@pr_Alarm_Limit", OleDbType.Decimal, Nothing)
        inpr_Alarm_Limit.Direction = ParameterDirection.Input
        inpr_Alarm_Limit.Value = pr_Alarm_Limit
        Dim inpr_Load_limit As OleDbParameter = cmd.Parameters.Add("@pr_Load_limit", OleDbType.Decimal, Nothing)
        inpr_Load_limit.Direction = ParameterDirection.Input
        inpr_Load_limit.Value = pr_Load_limit
        Dim inpr_NIBP As OleDbParameter = cmd.Parameters.Add("@pr_NIBP", OleDbType.Decimal, Nothing)
        inpr_NIBP.Direction = ParameterDirection.Input
        inpr_NIBP.Value = pr_NIBP
        Dim inlc_Load As OleDbParameter = cmd.Parameters.Add("@lc_Load", OleDbType.Decimal, Nothing)
        inlc_Load.Direction = ParameterDirection.Input
        inlc_Load.Value = lc_Load
        Dim inlc_Increase_of_Load As OleDbParameter = cmd.Parameters.Add("@lc_Increase_of_Load", OleDbType.Decimal, Nothing)
        inlc_Increase_of_Load.Direction = ParameterDirection.Input
        inlc_Increase_of_Load.Value = lc_Increase_of_Load
        Dim inlc_Training_Duration As OleDbParameter = cmd.Parameters.Add("@lc_Training_Duration", OleDbType.Decimal, Nothing)
        inlc_Training_Duration.Direction = ParameterDirection.Input
        inlc_Training_Duration.Value = lc_Training_Duration
        Dim inlc_Training_Load As OleDbParameter = cmd.Parameters.Add("@lc_Training_Load", OleDbType.Decimal, Nothing)
        inlc_Training_Load.Direction = ParameterDirection.Input
        inlc_Training_Load.Value = lc_Training_Load
        Dim inlc_Relative_Decrease_of_Load As OleDbParameter = cmd.Parameters.Add("@lc_Relative_Decrease_of_Load", OleDbType.Decimal, Nothing)
        inlc_Relative_Decrease_of_Load.Direction = ParameterDirection.Input
        inlc_Relative_Decrease_of_Load.Value = lc_Relative_Decrease_of_Load
        Dim inlc_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@lc_Alarm_Limit", OleDbType.Decimal, Nothing)
        inlc_Alarm_Limit.Direction = ParameterDirection.Input
        inlc_Alarm_Limit.Value = lc_Alarm_Limit
        Dim inlc_Load_limit As OleDbParameter = cmd.Parameters.Add("@lc_Load_limit", OleDbType.Decimal, Nothing)
        inlc_Load_limit.Direction = ParameterDirection.Input
        inlc_Load_limit.Value = lc_Load_limit
        Dim inlc_NIBP As OleDbParameter = cmd.Parameters.Add("@lc_NIBP", OleDbType.Decimal, Nothing)
        inlc_NIBP.Direction = ParameterDirection.Input
        inlc_NIBP.Value = lc_NIBP
        Dim inli_Load As OleDbParameter = cmd.Parameters.Add("@li_Load", OleDbType.Decimal, Nothing)
        inli_Load.Direction = ParameterDirection.Input
        inli_Load.Value = li_Load
        Dim inli_Increase_of_Load As OleDbParameter = cmd.Parameters.Add("@li_Increase_of_Load", OleDbType.Decimal, Nothing)
        inli_Increase_of_Load.Direction = ParameterDirection.Input
        inli_Increase_of_Load.Value = li_Increase_of_Load
        Dim inli_Training_Duration As OleDbParameter = cmd.Parameters.Add("@li_Training_Duration", OleDbType.Decimal, Nothing)
        inli_Training_Duration.Direction = ParameterDirection.Input
        inli_Training_Duration.Value = li_Training_Duration
        Dim inli_Upper_Level As OleDbParameter = cmd.Parameters.Add("@li_Upper_Level", OleDbType.Decimal, Nothing)
        inli_Upper_Level.Direction = ParameterDirection.Input
        inli_Upper_Level.Value = li_Upper_Level
        Dim inli_Relative_Decrease_of_Load As OleDbParameter = cmd.Parameters.Add("@li_Relative_Decrease_of_Load", OleDbType.Decimal, Nothing)
        inli_Relative_Decrease_of_Load.Direction = ParameterDirection.Input
        inli_Relative_Decrease_of_Load.Value = li_Relative_Decrease_of_Load
        Dim inli_Min_Time_Upper As OleDbParameter = cmd.Parameters.Add("@li_Min_Time_Upper", OleDbType.Decimal, Nothing)
        inli_Min_Time_Upper.Direction = ParameterDirection.Input
        inli_Min_Time_Upper.Value = li_Min_Time_Upper
        Dim inli_Min_Time_Lower As OleDbParameter = cmd.Parameters.Add("@li_Min_Time_Lower", OleDbType.Decimal, Nothing)
        inli_Min_Time_Lower.Direction = ParameterDirection.Input
        inli_Min_Time_Lower.Value = li_Min_Time_Lower
        Dim inli_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@li_Alarm_Limit", OleDbType.Decimal, Nothing)
        inli_Alarm_Limit.Direction = ParameterDirection.Input
        inli_Alarm_Limit.Value = li_Alarm_Limit
        Dim inli_Load_limit As OleDbParameter = cmd.Parameters.Add("@li_Load_limit", OleDbType.Decimal, Nothing)
        inli_Load_limit.Direction = ParameterDirection.Input
        inli_Load_limit.Value = li_Load_limit
        Dim inli_NIBP As OleDbParameter = cmd.Parameters.Add("@li_NIBP", OleDbType.Decimal, Nothing)
        inli_NIBP.Direction = ParameterDirection.Input
        inli_NIBP.Value = li_NIBP
        Dim inlr_Load As OleDbParameter = cmd.Parameters.Add("@lr_Load", OleDbType.Decimal, Nothing)
        inlr_Load.Direction = ParameterDirection.Input
        inlr_Load.Value = lr_Load
        Dim inlr_Increase_of_Load As OleDbParameter = cmd.Parameters.Add("@lr_Increase_of_Load", OleDbType.Decimal, Nothing)
        inlr_Increase_of_Load.Direction = ParameterDirection.Input
        inlr_Increase_of_Load.Value = lr_Increase_of_Load
        Dim inlr_Training_Duration As OleDbParameter = cmd.Parameters.Add("@lr_Training_Duration", OleDbType.Decimal, Nothing)
        inlr_Training_Duration.Direction = ParameterDirection.Input
        inlr_Training_Duration.Value = lr_Training_Duration
        Dim inlr_Upper_Level As OleDbParameter = cmd.Parameters.Add("@lr_Upper_Level", OleDbType.Decimal, Nothing)
        inlr_Upper_Level.Direction = ParameterDirection.Input
        inlr_Upper_Level.Value = lr_Upper_Level
        Dim inlr_Relative_Decrease_of_Load As OleDbParameter = cmd.Parameters.Add("@lr_Relative_Decrease_of_Load", OleDbType.Decimal, Nothing)
        inlr_Relative_Decrease_of_Load.Direction = ParameterDirection.Input
        inlr_Relative_Decrease_of_Load.Value = lr_Relative_Decrease_of_Load
        Dim inlr_Time_for_Decrease As OleDbParameter = cmd.Parameters.Add("@lr_Time_for_Decrease", OleDbType.Decimal, Nothing)
        inlr_Time_for_Decrease.Direction = ParameterDirection.Input
        inlr_Time_for_Decrease.Value = lr_Time_for_Decrease
        Dim inlr_Increase As OleDbParameter = cmd.Parameters.Add("@lr_Increase", OleDbType.Decimal, Nothing)
        inlr_Increase.Direction = ParameterDirection.Input
        inlr_Increase.Value = lr_Increase
        Dim inlr_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@lr_Alarm_Limit", OleDbType.Decimal, Nothing)
        inlr_Alarm_Limit.Direction = ParameterDirection.Input
        inlr_Alarm_Limit.Value = lr_Alarm_Limit
        Dim inlr_Load_limit As OleDbParameter = cmd.Parameters.Add("@lr_Load_limit", OleDbType.Decimal, Nothing)
        inlr_Load_limit.Direction = ParameterDirection.Input
        inlr_Load_limit.Value = lr_Load_limit
        Dim inlr_NIBP As OleDbParameter = cmd.Parameters.Add("@lr_NIBP", OleDbType.Decimal, Nothing)
        inlr_NIBP.Direction = ParameterDirection.Input
        inlr_NIBP.Value = lr_NIBP
        Dim inlf_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@lf_Alarm_Limit", OleDbType.Decimal, Nothing)
        inlf_Alarm_Limit.Direction = ParameterDirection.Input
        inlf_Alarm_Limit.Value = lf_Alarm_Limit
        Dim inlf_NIBP As OleDbParameter = cmd.Parameters.Add("@lf_NIBP", OleDbType.Decimal, Nothing)
        inlf_NIBP.Direction = ParameterDirection.Input
        inlf_NIBP.Value = lf_NIBP
        Dim intt_w1_speed_m As OleDbParameter = cmd.Parameters.Add("@tt_w1_speed_m", OleDbType.Decimal, Nothing)
        intt_w1_speed_m.Direction = ParameterDirection.Input
        intt_w1_speed_m.Value = tt_w1_speed_m
        Dim intt_w1_speed_km As OleDbParameter = cmd.Parameters.Add("@tt_w1_speed_km", OleDbType.Decimal, Nothing)
        intt_w1_speed_km.Direction = ParameterDirection.Input
        intt_w1_speed_km.Value = tt_w1_speed_km
        Dim intt_w_slope As OleDbParameter = cmd.Parameters.Add("@tt_w_slope", OleDbType.Decimal, Nothing)
        intt_w_slope.Direction = ParameterDirection.Input
        intt_w_slope.Value = tt_w_slope
        Dim intt_w2_speed_m As OleDbParameter = cmd.Parameters.Add("@tt_w2_speed_m", OleDbType.Decimal, Nothing)
        intt_w2_speed_m.Direction = ParameterDirection.Input
        intt_w2_speed_m.Value = tt_w2_speed_m
        Dim intt_w2_speed_km As OleDbParameter = cmd.Parameters.Add("@tt_w2_speed_km", OleDbType.Decimal, Nothing)
        intt_w2_speed_km.Direction = ParameterDirection.Input
        intt_w2_speed_km.Value = tt_w2_speed_km
        Dim intt_Increase_of_slope As OleDbParameter = cmd.Parameters.Add("@tt_Increase_of_slope", OleDbType.Decimal, Nothing)
        intt_Increase_of_slope.Direction = ParameterDirection.Input
        intt_Increase_of_slope.Value = tt_Increase_of_slope
        Dim intt_Training_Duration As OleDbParameter = cmd.Parameters.Add("@tt_Training_Duration", OleDbType.Decimal, Nothing)
        intt_Training_Duration.Direction = ParameterDirection.Input
        intt_Training_Duration.Value = tt_Training_Duration
        Dim intt_tr_speed_m As OleDbParameter = cmd.Parameters.Add("@tt_tr_speed_m", OleDbType.Decimal, Nothing)
        intt_tr_speed_m.Direction = ParameterDirection.Input
        intt_tr_speed_m.Value = tt_tr_speed_m
        Dim intt_tr_speed_km As OleDbParameter = cmd.Parameters.Add("@tt_tr_speed_km", OleDbType.Decimal, Nothing)
        intt_tr_speed_km.Direction = ParameterDirection.Input
        intt_tr_speed_km.Value = tt_tr_speed_km
        Dim intt_Distance As OleDbParameter = cmd.Parameters.Add("@tt_Distance", OleDbType.Decimal, Nothing)
        intt_Distance.Direction = ParameterDirection.Input
        intt_Distance.Value = tt_Distance
        Dim intt_tr_slope As OleDbParameter = cmd.Parameters.Add("@tt_tr_slope", OleDbType.Decimal, Nothing)
        intt_tr_slope.Direction = ParameterDirection.Input
        intt_tr_slope.Value = tt_tr_slope
        Dim intt_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@tt_Alarm_Limit", OleDbType.Decimal, Nothing)
        intt_Alarm_Limit.Direction = ParameterDirection.Input
        intt_Alarm_Limit.Value = tt_Alarm_Limit
        Dim intt_NIBP As OleDbParameter = cmd.Parameters.Add("@tt_NIBP", OleDbType.Decimal, Nothing)
        intt_NIBP.Direction = ParameterDirection.Input
        intt_NIBP.Value = tt_NIBP
        Dim intp_w1_speed_m As OleDbParameter = cmd.Parameters.Add("@tp_w1_speed_m", OleDbType.Decimal, Nothing)
        intp_w1_speed_m.Direction = ParameterDirection.Input
        intp_w1_speed_m.Value = tp_w1_speed_m
        Dim intp_w1_speed_km As OleDbParameter = cmd.Parameters.Add("@tp_w1_speed_km", OleDbType.Decimal, Nothing)
        intp_w1_speed_km.Direction = ParameterDirection.Input
        intp_w1_speed_km.Value = tp_w1_speed_km
        Dim intp_w_slope As OleDbParameter = cmd.Parameters.Add("@tp_w_slope", OleDbType.Decimal, Nothing)
        intp_w_slope.Direction = ParameterDirection.Input
        intp_w_slope.Value = tp_w_slope
        Dim intp_w2_speed_m As OleDbParameter = cmd.Parameters.Add("@tp_w2_speed_m", OleDbType.Decimal, Nothing)
        intp_w2_speed_m.Direction = ParameterDirection.Input
        intp_w2_speed_m.Value = tp_w2_speed_m
        Dim intp_w2_speed_km As OleDbParameter = cmd.Parameters.Add("@tp_w2_speed_km", OleDbType.Decimal, Nothing)
        intp_w2_speed_km.Direction = ParameterDirection.Input
        intp_w2_speed_km.Value = tp_w2_speed_km
        Dim intp_Increase_of_slope As OleDbParameter = cmd.Parameters.Add("@tp_Increase_of_slope", OleDbType.Decimal, Nothing)
        intp_Increase_of_slope.Direction = ParameterDirection.Input
        intp_Increase_of_slope.Value = tp_Increase_of_slope
        Dim intp_Training_Duration As OleDbParameter = cmd.Parameters.Add("@tp_Training_Duration", OleDbType.Decimal, Nothing)
        intp_Training_Duration.Direction = ParameterDirection.Input
        intp_Training_Duration.Value = tp_Training_Duration
        Dim intp_tr_speed_m As OleDbParameter = cmd.Parameters.Add("@tp_tr_speed_m", OleDbType.Decimal, Nothing)
        intp_tr_speed_m.Direction = ParameterDirection.Input
        intp_tr_speed_m.Value = tp_tr_speed_m
        Dim intp_tr_speed_km As OleDbParameter = cmd.Parameters.Add("@tp_tr_speed_km", OleDbType.Decimal, Nothing)
        intp_tr_speed_km.Direction = ParameterDirection.Input
        intp_tr_speed_km.Value = tp_tr_speed_km
        Dim intp_HR_Min As OleDbParameter = cmd.Parameters.Add("@tp_HR_Min", OleDbType.Decimal, Nothing)
        intp_HR_Min.Direction = ParameterDirection.Input
        intp_HR_Min.Value = tp_HR_Min
        Dim intp_HR_Max As OleDbParameter = cmd.Parameters.Add("@tp_HR_Max", OleDbType.Decimal, Nothing)
        intp_HR_Max.Direction = ParameterDirection.Input
        intp_HR_Max.Value = tp_HR_Max
        Dim intp_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@tp_Alarm_Limit", OleDbType.Decimal, Nothing)
        intp_Alarm_Limit.Direction = ParameterDirection.Input
        intp_Alarm_Limit.Value = tp_Alarm_Limit
        Dim intp_NIBP As OleDbParameter = cmd.Parameters.Add("@tp_NIBP", OleDbType.Decimal, Nothing)
        intp_NIBP.Direction = ParameterDirection.Input
        intp_NIBP.Value = tp_NIBP
        Dim inIPN_gender As OleDbParameter = cmd.Parameters.Add("@IPN_gender", OleDbType.Decimal, Nothing)
        inIPN_gender.Direction = ParameterDirection.Input
        inIPN_gender.Value = IPN_gender
        Dim inIPN_Wt As OleDbParameter = cmd.Parameters.Add("@IPN_Wt", OleDbType.VarChar, 100)
        inIPN_Wt.Direction = ParameterDirection.Input
        inIPN_Wt.Value = IPN_Wt
        Dim inIPN_Age As OleDbParameter = cmd.Parameters.Add("@IPN_Age", OleDbType.VarChar, 100)
        inIPN_Age.Direction = ParameterDirection.Input
        inIPN_Age.Value = IPN_Age
        Dim inIPN_Resting_HR As OleDbParameter = cmd.Parameters.Add("@IPN_Resting_HR", OleDbType.VarChar, 100)
        inIPN_Resting_HR.Direction = ParameterDirection.Input
        inIPN_Resting_HR.Value = IPN_Resting_HR
        Dim inIPN_Option As OleDbParameter = cmd.Parameters.Add("@IPN_Option", OleDbType.Decimal, Nothing)
        inIPN_Option.Direction = ParameterDirection.Input
        inIPN_Option.Value = IPN_Option
        Dim inIPN_Target_HR As OleDbParameter = cmd.Parameters.Add("@IPN_Target_HR", OleDbType.VarChar, 100)
        inIPN_Target_HR.Direction = ParameterDirection.Input
        inIPN_Target_HR.Value = IPN_Target_HR
        Dim inIPN_Protocol As OleDbParameter = cmd.Parameters.Add("@IPN_Protocol", OleDbType.Decimal, Nothing)
        inIPN_Protocol.Direction = ParameterDirection.Input
        inIPN_Protocol.Value = IPN_Protocol
        Dim inFree_def As OleDbParameter = cmd.Parameters.Add("@Free_def", OleDbType.VarChar, 100)
        inFree_def.Direction = ParameterDirection.Input
        inFree_def.Value = Free_def
        Dim inFecg_Training_Duration As OleDbParameter = cmd.Parameters.Add("@Fecg_Training_Duration", OleDbType.Decimal, Nothing)
        inFecg_Training_Duration.Direction = ParameterDirection.Input
        inFecg_Training_Duration.Value = Fecg_Training_Duration
        Dim inFecg_Alarm_Limit As OleDbParameter = cmd.Parameters.Add("@Fecg_Alarm_Limit", OleDbType.Decimal, Nothing)
        inFecg_Alarm_Limit.Direction = ParameterDirection.Input
        inFecg_Alarm_Limit.Value = Fecg_Alarm_Limit
        Dim inFecg_NIBP As OleDbParameter = cmd.Parameters.Add("@Fecg_NIBP", OleDbType.Decimal, Nothing)
        inFecg_NIBP.Direction = ParameterDirection.Input
        inFecg_NIBP.Value = Fecg_NIBP
        Dim inAlarm_NIBP As OleDbParameter = cmd.Parameters.Add("@Alarm_NIBP", OleDbType.VarChar, 100)
        inAlarm_NIBP.Direction = ParameterDirection.Input
        inAlarm_NIBP.Value = Alarm_NIBP
        Dim inAlarm_SPO2 As OleDbParameter = cmd.Parameters.Add("@Alarm_SPO2", OleDbType.VarChar, 100)
        inAlarm_SPO2.Direction = ParameterDirection.Input
        inAlarm_SPO2.Value = Alarm_SPO2
#End Region
        Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
        outError.Direction = ParameterDirection.Output

        conn.Open()
        cmd.ExecuteReader()
        conn.Close()

        Dim idkine = CInt(cmd.Parameters("@outError").Value)

        Return CInt(cmd.Parameters("@outError").Value)
    End Function
    Private Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click
        Try
            lbl_total.Visible = True
            Me.Cursor = Cursors.WaitCursor
            bar_progreso.Maximum = dg_data.Rows.Count - 1
            bar_progreso.Value = 0
            For Each row As DataGridViewRow In dg_data.Rows
                If bar_progreso.Value < dg_data.Rows.Count - 1 Then
                    exportarData(IIf(row.Cells(0).Value.ToString = "", 0,
                             row.Cells(0).Value), row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value,
                             row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(16).Value, row.Cells(17).Value, row.Cells(18).Value, row.Cells(19).Value, row.Cells(20).Value,
                             row.Cells(21).Value, row.Cells(22).Value, row.Cells(23).Value, row.Cells(24).Value, row.Cells(25).Value, row.Cells(26).Value, row.Cells(27).Value, row.Cells(28).Value, row.Cells(29).Value, row.Cells(30).Value,
                             row.Cells(31).Value, row.Cells(32).Value, row.Cells(33).Value, row.Cells(34).Value, row.Cells(35).Value, row.Cells(36).Value, row.Cells(37).Value, row.Cells(38).Value, row.Cells(39).Value, row.Cells(40).Value,
                             row.Cells(41).Value, row.Cells(42).Value, row.Cells(43).Value, row.Cells(44).Value, row.Cells(45).Value, row.Cells(46).Value, row.Cells(47).Value, row.Cells(48).Value, row.Cells(49).Value, row.Cells(50).Value,
                             row.Cells(51).Value, row.Cells(52).Value, row.Cells(53).Value, row.Cells(54).Value, row.Cells(55).Value, row.Cells(56).Value, row.Cells(57).Value, row.Cells(58).Value, row.Cells(59).Value, row.Cells(60).Value,
                             row.Cells(61).Value, row.Cells(62).Value, row.Cells(63).Value, row.Cells(64).Value, row.Cells(65).Value, row.Cells(66).Value, row.Cells(67).Value, row.Cells(68).Value, row.Cells(69).Value, row.Cells(70).Value,
                             row.Cells(71).Value, row.Cells(72).Value, row.Cells(73).Value, row.Cells(74).Value, row.Cells(75).Value, row.Cells(76).Value, row.Cells(77).Value, row.Cells(78).Value, row.Cells(79).Value, row.Cells(80).Value,
                             row.Cells(81).Value, row.Cells(82).Value, row.Cells(83).Value, row.Cells(84).Value, row.Cells(85).Value, row.Cells(86).Value, row.Cells(87).Value, row.Cells(88).Value, row.Cells(89).Value, row.Cells(90).Value,
                             row.Cells(91).Value, row.Cells(92).Value, row.Cells(93).Value, row.Cells(94).Value, row.Cells(95).Value, row.Cells(96).Value, row.Cells(97).Value, row.Cells(98).Value, row.Cells(99).Value)
                    bar_progreso.Value = bar_progreso.Value + 1
                    lbl_total.Text = bar_progreso.Value.ToString + "/" + bar_progreso.Maximum.ToString + " datos exportados"
                    lbl_total.Refresh()
                End If
            Next row
            MessageBox.Show("Datos exportados correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btn_ruta_Click(sender As Object, e As EventArgs) Handles btn_ruta.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            lbl_ruta.Text = OpenFileDialog1.FileName
            cargarData()
            GroupBox1.Visible = True
        End If
    End Sub
    Private Sub cargarData()
        dg_data.DataSource = Nothing
        Dim connectString As String = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=" + lbl_ruta.Text
        Dim cn As OleDbConnection = New OleDbConnection(connectString)
        cn.Open()
        Dim selectString As String = "SELECT External_id,
        Patient_id, Test_type, pp_Load, pp_Increase_of_Load, pp_Training_Duration, pp_Training_HR, pp_Relative_Decrease_of_Load, pp_Alarm_Limit, pp_Load_limit, pp_NIBP, pi_Load, pi_Increase_of_Load, 
        pi_Training_Duration, pi_Training_HR, pi_Relative_Decrease_of_Load, pi_Min_Time, pi_Time_Lower_Level, pi_Alarm_Limit, pi_Load_limit, pi_NIBP, pr_Load, pr_Increase_of_Load, pr_Training_Duration, 
        pr_Training_HR, pr_Relative_Decrease_of_Load, pr_Time_for_Decrease, pr_Increase, pr_Alarm_Limit, pr_Load_limit, pr_NIBP, lc_Load, lc_Increase_of_Load, lc_Training_Duration, lc_Training_Load, 
        lc_Relative_Decrease_of_Load, lc_Alarm_Limit, lc_Load_limit, lc_NIBP, li_Load, li_Increase_of_Load, li_Training_Duration, li_Upper_Level, li_Relative_Decrease_of_Load, li_Min_Time_Upper, 
        li_Min_Time_Lower, li_Alarm_Limit, li_Load_limit, li_NIBP, lr_Load, lr_Increase_of_Load, lr_Training_Duration, lr_Upper_Level, lr_Relative_Decrease_of_Load, lr_Time_for_Decrease, lr_Increase, 
        lr_Alarm_Limit, lr_Load_limit, lr_NIBP, lf_Alarm_Limit, lf_NIBP, tt_w1_speed_m, tt_w1_speed_km, tt_w_slope, tt_w2_speed_m, tt_w2_speed_km, tt_Increase_of_slope, tt_Training_Duration, tt_tr_speed_m, 
        tt_tr_speed_km, tt_Distance, tt_tr_slope, tt_Alarm_Limit, tt_NIBP, tp_w1_speed_m, tp_w1_speed_km, tp_w_slope, tp_w2_speed_m, tp_w2_speed_km, tp_Increase_of_slope, tp_Training_Duration, tp_tr_speed_m, 
        tp_tr_speed_km, tp_HR_Min, tp_HR_Max, tp_Alarm_Limit, tp_NIBP, IPN_gender, IPN_Wt, IPN_Age, IPN_Resting_HR, IPN_Option, IPN_Target_HR, IPN_Protocol, Free_def, Fecg_Training_Duration, Fecg_Alarm_Limit, 
        Fecg_NIBP, Alarm_NIBP, Alarm_SPO2
        FROM TRAINING_PARAMETERS, VISIT_TABLE, PATIENT_TABLE
        WHERE TRAINING_PARAMETERS.PATIENT_ID = CINT(VISIT_TABLE.INTERNAL_ID) AND TRAINING_PARAMETERS.PATIENT_ID = PATIENT_TABLE.INTERNAL_ID AND
        Format(visitdatetime, ""Short Date"")=Format(@fecha, ""Short Date"")"
        Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
        cmd.Parameters.AddWithValue("@fecha", DateTime.Parse("23/11/2018"))
        Dim reader As OleDbDataReader = cmd.ExecuteReader()
        dt.Load(reader)
        dg_data.DataSource = dt
        dg_data.Columns(1).ReadOnly = True
    End Sub
End Class
