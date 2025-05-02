<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemporyPunching.aspx.cs" Inherits="WebApplication1.TemporyPunching" EnableEventValidation="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Punching System</title>

    <!-- Google Font: Roboto -->
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" rel="stylesheet">
    
    <!-- Bootstrap Core CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <style>
        body {
            font-family: 'Roboto', sans-serif;
            background-color: #f2f7ff;
            color: black;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 0;
        }

        .container-custom {
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
            padding: 30px;
            background-color: #eaf4ff;
            border-radius: 15px;
            box-shadow: 0px 4px 20px rgba(0, 0, 0, 0.1);
            width: 70%;
            max-width: 1200px;
        }

        .form-section {
            width: 50%;
            padding-right: 20px;
        }

        h2 {
            text-align: left;
            margin-bottom: 30px;
            color: #333;
            font-weight: 700;
        }

        label {
            color: #555;
            font-weight: 500;
            margin-bottom: 8px;
        }

        .btn-custom {
            background-color: #95a5a6;
            color: white;
            padding: 10px 30px;
            border-radius: 5px;
            margin: 10px;
             text-align: center;      
            display: inline-block; 
            }

        .btn-custom:hover {
            background-color:#28a745;
        }

        .btn-danger-custom {
            background-color: #555;
            color: white;
            padding: 10px 30px;
            border-radius: 5px;
            margin: 10px;
            }

        .btn-danger-custom:hover {
            background-color: #c82333;
        }

        .custom-input {
            background-color: #fff;
            color: black;
            border: 1px solid #ccc;
            padding: 05px;
            border-radius: 5px;
            width: 100%;
            margin-bottom: 20px;
        }
        .custom-label {
            font-size: 12px; 
            padding: 2px;    
            margin: 5px 0;   
            color: black;    
        }
        #videoElement {
            width: 100%;
            border-radius: 10px;
            border: 2px solid #444;
            background-color: #fff;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 240px;
            color: #666;
        }

        .date-time-section {
            display: flex;
            justify-content: space-between;
            margin-bottom: 15px;
            font-size: 16px;
        }

        .date, .time {
            font-weight: 500;
        }
        .video-section {
             width: 40%;
             display: flex;
                flex-direction: column;
                 align-items: center;
            margin-top: 20px; /* Adds space above the section */
           padding-top: 10px; /* Adds extra space inside the section if needed */
}

        #videoElement {
             width: 100%;
             height: 70%;
             border-radius: 10px;
              border: 2px solid #444;
              margin-top: 50px; /* Adds space above the video element */
                }
    </style>
    
    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript">
        function startVideo() {
            var video = document.querySelector("#videoElement");

            if (navigator.mediaDevices.getUserMedia) {
                navigator.mediaDevices.getUserMedia({ video: true })
                    .then(function (stream) {
                        video.srcObject = stream;
                    })
                    .catch(function (error) {
                        console.log("Something went wrong with video capture: ", error);
                    });
            }
        }

        function captureImage() {
            var canvas = document.createElement("canvas");
            var video = document.querySelector("#videoElement");
            canvas.width = video.videoWidth;
            canvas.height = video.videoHeight;
            var context = canvas.getContext("2d");
            context.drawImage(video, 0, 0, canvas.width, canvas.height);
            var dataURL = canvas.toDataURL("image/png");
            document.getElementById("videoData").value = dataURL;
        }

        function displayDateTime() {
            const dateElement = document.getElementById('currentDate');
            const timeElement = document.getElementById('currentTime');

            function updateDateTime() {
                const now = new Date();
                dateElement.innerText = now.toLocaleDateString();
                timeElement.innerText = now.toLocaleTimeString();
            }

            updateDateTime();
            setInterval(updateDateTime, 1000);
        }

        function validateLogin() {
            console.log("validateLogin function called");

            if (typeof (__doPostBack) === 'function') {
                //in __doPostBack case password is cleared so password is stored in a hidden field
                document.getElementById('<%= passwordHidden.ClientID %>').value = document.getElementById('<%= txt_password.ClientID %>').value;

                __doPostBack('ValidatePostBack', 'validateLogin');
            } else {
                console.error("__doPostBack is not defined. Make sure ScriptManager is included.");
            }
        }

        $(document).ready(function () {
            startVideo();
            displayDateTime();
        });
            function setFocusOnSubmit() {
                document.getElementById('<%= btnSubmit.ClientID %>').focus();
             }

    </script>
</head>
<body>
    <div class="container-custom">
        <div class="form-section">
            <!-- Date and Time -->
            <div class="date-time-section">
                <div class="date">
                    <span class="icon">&#128197;</span>
                    <span id="currentDate"></span>
                </div>
                <div class="time">
                    <span class="icon">&#128337;</span>
                    <span id="currentTime"></span>
                </div>
            </div>

            <!-- Form Section -->
            <center><h6>PUNCHMASTER</h6></center>
            <form id="form1" runat="server">
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                
                <div class="form-group">
                    <label for="txt_username" class="custom-label">USERNAME:</label>
                    <asp:TextBox ID="txt_username" runat="server" CssClass="custom-input" autocomplete="off"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label for="password" class="custom-label">PASSWORD:</label>
                    <asp:TextBox ID="txt_password" runat="server" TextMode="Password" CssClass="custom-input" onchange="validateLogin()" autocomplete="off"></asp:TextBox>
                    <asp:HiddenField ID="passwordHidden" runat="server" />
                </div>
                
                <div class="form-group">
                    <label for="login_user" class="custom-label">LOGIN USER:</label>
                    <asp:TextBox ID="login_user" runat="server" CssClass="custom-input" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="Shift" class="custom-label">SHIFT:</label>
                    <asp:TextBox ID="txt_shift" runat="server" CssClass="custom-input" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group text-center">
                    <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn-danger-custom" OnClick="btnReject_Click" Width="146px" Height="45px" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-custom" OnClientClick="captureImage()" OnClick="btnSubmit_ClickNew" Width="149px" Height="45px" />
                </div>

                <!-- Hidden Field for Video Data -->
                <asp:HiddenField ID="videoData" runat="server" />
            </form>
        </div>

        <!-- Video Section -->
        <div class="video-section">
            <video autoplay="true" id="videoElement"></video>
        </div>
    </div>
</body>
</html>