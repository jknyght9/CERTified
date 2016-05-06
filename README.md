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