<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="reporte.aspx.vb" Inherits="Kaplan.reporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<form id="form1" runat="server">
    <div style="width: 100%; height: 100%">
        <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="1500px" ShowPrintButton="True" SizeToReportContent="True" Visible="False">
            <LocalReport ReportPath="reports\nutricion.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="1500px" ShowPrintButton="True" SizeToReportContent="True" Visible="False">
            <LocalReport ReportPath="reports\psicologia.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        <rsweb:ReportViewer ID="ReportViewer3" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="1500px" ShowPrintButton="True" SizeToReportContent="True" Visible="False">
            <LocalReport ReportPath="reports\kinesiologia.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        <rsweb:ReportViewer ID="ReportViewer4" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="1500px" ShowPrintButton="True" SizeToReportContent="True" Visible="False">
            <LocalReport ReportPath="reports\enfermeria.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        <rsweb:ReportViewer ID="ReportViewer5" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="1500px" ShowPrintButton="True" SizeToReportContent="True" Visible="False">
            <LocalReport ReportPath="reports\evolucion.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        <rsweb:ReportViewer ID="ReportViewer6" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="1500px" ShowPrintButton="True" SizeToReportContent="True" Visible="False">
            <LocalReport ReportPath="reports\medico.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</form>
