// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<System.Runtime.InteropServices.DllImport("kernel32.dll")>]
extern System.IntPtr GetConsoleWindow();

[<System.Runtime.InteropServices.DllImport("user32.dll")>]
extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);

[<EntryPoint>]
let main argv = 
    let handle = GetConsoleWindow()
    ShowWindow(handle, 0) |> ignore
    try
        let proces = new System.Diagnostics.Process()
        let pi = new System.Diagnostics.ProcessStartInfo()
        pi.CreateNoWindow <- true
        pi.UseShellExecute <- false
        if System.Convert.ToInt32 argv.[0] > 0 then
            pi.FileName <- @"C:\Program Files (x86)\3dEye\OnvifProcessingService\installservice.bat"
        else
            pi.FileName <- @"C:\Program Files (x86)\3dEye\OnvifProcessingService\uninstallservice.bat"
        proces.StartInfo <- pi;
        try
            proces.Start() |> ignore
        with
        | _ -> ()
        
    with
    | _ -> ()
    
    0 // return an integer exit code