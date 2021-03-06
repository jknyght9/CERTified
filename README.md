# CERTified

Verifies certificates registered in the Microsoft Windows Certificate Store. Features include:
- verifies Certificate Authorities with MS Certificate Trust List (CTL)
- pulls individual certificate Certificate Revocation List (CRL)
  - verifies certificate is not revoked
- validates certificate chain (e.g. is self-signed)
- checks certificate expiration
- constantly monitors certificate store
  - updates every 60 second
  - update refresh is user configurable
- CTL and CRL is updated every 6 hours
- Exiting program (top right "X") minimizes to notification bar
- notifies user when a new certificate is added to the store
- can view certificate information like: serial, thumbprint, algorithm, etc.

  ![Alt text](/../master/CERTified.PNG?raw=true "CERTified Screenshot")

## Instructions

Microsoft Visual Studio is required to compile the project. I used VS 2015 Community (free). Get it at https://go.microsoft.com/fwlink/?LinkId=691978&clcid=0x409
- install Visual Studio
- clone project
- open solution file (CERTified.sln) 
- at the top change the build type from "Debug" to "Release"
- click "Build" then "Build CERTified"
- copy "CERTified.exe" from ..\CERTified\CERTified\bin\Release to what ever directory you want
- run