�
KD:\GithubSvn\GitHub\TestCommitGithub\ImportDataExcel\ChangeDnsForm\Form1.cs
	namespace 	

 
{
public 

partial 
class 
Form1 
:  
Form! %
{ 
public 
Form1 
( 
) 
{ 	
InitializeComponent 
(  
)  !
;! "

= 
FormStartPosition -
.- .
Manual. 4
;4 5
Location 
= 
new 
Point  
(  !
$num! %
,% &
$num' *
)* +
;+ ,
} 	
private 
void 
btnChange_Click $
($ %
object% +
sender, 2
,2 3
	EventArgs4 =
e> ?
)? @
{ 	
var 
cardName 
= 
txtCardName &
.& '
Text' +
;+ ,
var 
dns1 
= 
txtDns1 
. 
Text #
;# $
var 
dns2 
= 
txtDns2 
. 
Text #
;# $

. 
RunChangeDns &
(& '
cardName' /
,/ 0
dns11 5
,5 6
dns27 ;
); <
;< =
var 

frmSuccess 
= 
new  
InformationForm! 0
(0 1
)1 2
;2 3

frmSuccess 
. 
Show 
( 
) 
; 
}   	
public"" 
void"" 
	CloseForm"" 
("" 
)"" 
{## 	
Application$$ 
.$$ 
Exit$$ 
($$ 
)$$ 
;$$ 
}%% 	
}&& 
}'' �

UD:\GithubSvn\GitHub\TestCommitGithub\ImportDataExcel\ChangeDnsForm\InformationForm.cs
	namespace 	

 
{ 
public

partial
class
InformationForm
:
Form
{ 
public 
InformationForm 
( 
)  
{ 	
InitializeComponent 
(  
)  !
;! "

= 
FormStartPosition -
.- .
Manual. 4
;4 5
Location 
= 
new 
Point  
(  !
$num! %
,% &
$num' *
)* +
;+ ,
} 	
private 
void 
btnOk_Click  
(  !
object! '
sender( .
,. /
	EventArgs0 9
e: ;
); <
{ 	
this 
. 
Close 
( 
) 
; 
Form1 
frm1 
= 
new 
Form1 "
(" #
)# $
;$ %
frm1 
. 
	CloseForm 
( 
) 
; 
} 	
} 
} �
MD:\GithubSvn\GitHub\TestCommitGithub\ImportDataExcel\ChangeDnsForm\Program.cs
	namespace 	

 
{ 
static		 

class		 
Program		 
{

 
[ 	
	STAThread	 
] 
static 
void 
Main 
( 
) 
{ 	
Application 
. 
EnableVisualStyles *
(* +
)+ ,
;, -
Application 
. -
!SetCompatibleTextRenderingDefault 9
(9 :
false: ?
)? @
;@ A
Application 
. 
Run 
( 
new 
Form1  %
(% &
)& '
)' (
;( )
} 	
} 
} �
]D:\GithubSvn\GitHub\TestCommitGithub\ImportDataExcel\ChangeDnsForm\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 


( 
$str (
)( )
]) *
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str *
)* +
]+ ,
[
assembly
:

AssemblyCopyright
(
$str
)
]
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *