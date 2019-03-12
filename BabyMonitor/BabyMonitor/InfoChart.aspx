<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoChart.aspx.cs" Inherits="BabyMonitor.InfoChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="border:hidden; font-family: Arial">
                <tr>
                    <td>
                        <b>Select Visualization Type:</b>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Chart ID="Chart1" runat="server" Width="880px" Height="260px" style="padding:0px">
                            <Series>
                                <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Line">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" >
                                    <AxisY Title="Temperature(Celsius)">
                                    </AxisY>
                                    <AxisX Title="Date&Time" Interval="10">
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                            <Titles>
                                <asp:Title Name="Title1" Text="Temperature Sensor Data">
                                </asp:Title>
                            </Titles>
                        </asp:Chart>
                    </td>
                </tr>

            </table>

        </div>
    </form>
</body>
</html>
