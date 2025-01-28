<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transaction.aspx.cs" Inherits="Rentify.transaction" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }
        .container {
            max-width: 600px;
            margin: 50px auto;
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            color: #333;
        }
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }
        input[type="date"], input[type="submit"] {
            width: 95%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        input[type="submit"] {
            background: #4CAF50;
            color: white;
            cursor: pointer;
             width: 95%;
        }
        input[type="submit"]:hover {
            background: #45a049;
        }
    </style>
    <script>
        window.onload = function () {
            const startDateInput = document.getElementById('<%= txtStartDate.ClientID %>');
            const endDateInput = document.getElementById('<%= txtEndDate.ClientID %>');
            const submitButton = document.getElementById('<%= btnSubmit.ClientID %>');

            const today = new Date();
            const minDate = today.toISOString().split('T')[0];

            // Set the minimum start date to today
            startDateInput.setAttribute('min', minDate);

            // Validate dates on submit
            submitButton.addEventListener('click', function (e) {
                const startDateValue = new Date(startDateInput.value);
                const endDateValue = new Date(endDateInput.value);

                if (!startDateInput.value || !endDateInput.value) {
                    alert('Please select both start and end dates.');
                    e.preventDefault();
                    return;
                }

                // Check if the start date is greater than or equal to today
                if (startDateValue < today) {
                    alert('The start date must be today or a future date.');
                    e.preventDefault();
                    return;
                }

                // Check if the difference between dates is one month
                const oneMonthLater = new Date(startDateValue);
                oneMonthLater.setMonth(oneMonthLater.getMonth() + 1);

                if (
                    oneMonthLater.getFullYear() !== endDateValue.getFullYear() ||
                    oneMonthLater.getMonth() !== endDateValue.getMonth() ||
                    oneMonthLater.getDate() !== endDateValue.getDate()
                ) {
                    alert('The gap between the start date and end date must be exactly one month.');
                    e.preventDefault();
                    return;
                }
            });
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Transaction Page</h1>
            <p>Welcome to the transaction page. Please enter the rental details below:</p>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <label for="startDate">Rented Start Date:</label>
            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>

            <label for="endDate">Rented End Date:</label>
            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit Transaction" OnClick="btnSubmit_Click"  />

             <asp:Button ID="btnBack" runat="server" Text="Back DashBoard Transaction" OnClick="btnBack_Click"  />
        </div>
    </form>
</body>
</html>
