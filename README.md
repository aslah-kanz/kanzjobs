# Kanz Cron


# Installation step
Update and install dotnet sdk with following command

    sudo apt-get update &&   sudo apt-get install -y dotnet-sdk-8.0

Clone repository the desired folder 

    git clone git@github.com:kanzway/kanzjobs.git
Open folder where you clone it and run this command

    dotnet build && dotnet publish -c Release -o /var/www/ --runtime linux-x64

this command will publish kanzjob executable file on /var/www 
edit the appsetting.Development.json accordingly 

                                            {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning",
          "Hangfire": "Information"
        }
      },
      "ConnectionStrings": {
        "HangfireConnection": "connection string for hangfire database currently KanzJob databse"    
        "KanzwayConnection": "connection string for Kanzway API"  
      },
      "KanzwaySetting": {
        "ExpirePendingPaymentInHours": 24, //set expire payment 24 hours
        "KanzApiUrl": "Kanzway API URL",
        "CronCleanupMinute": 59, //Update all expired payment to cancel every 59 minutes
        "CronPendingPayment": 5 //Pending payment notification every 5 minutes
      }
    }


   
Create a daemon service

run following command 

    nano /etc/systemd/system/app.service

Then copy following script
    
    [Unit]
    Description=KanzWay jobs[Service]
    WorkingDirectory=/var/www/
    ExecStart=/usr/bin/dotnet /var/www/KanzwayCron.dll
    Restart=always
    #Restart service after 10 seconds if the dotnet service crashes:
    RestartSec=10
    KillSignal=SIGINT
    SyslogIdentifier=kanzway-jobs
    User=root
    Environment=ASPNETCORE_ENVIRONMENT=Development
    
    [Install]
    WantedBy=multi-user.target

   After save the script, run following command 

    systemctl start app

and this command to check log and status

    journalctl -e -u app

to access dashboard you can browse it on 

    http://{Your URL / localhost}:5000/dashboard
