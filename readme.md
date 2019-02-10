This repo is the companion project containing example for the blog series at https://www.frakkingsweet.com/net-core-correlation-id/.

There are 2 projects, the source (frontend site) and target (backend service).

To use it:
1) Build
2) Start a debug session of the target project
3) Start a debug session of the source project
4) Navigate to the url: https://localhost:44361/Do/Something
5) To see the headers your browser send, navigate to https://localhost:44324/Headers/Dump

When you hit the url at https://localhost:44361/Do/Something, it will make a single request to https://localhost:44324/Headers/Dump. You will see in your debugger a lot of messages, the first hit loads a lot of libraries so you'll also see a bunch of junk. I clear the log and hit it again to get a clean output of log entries. I then copy those and paste them into Visual Studio Code and format the json to view the entries.