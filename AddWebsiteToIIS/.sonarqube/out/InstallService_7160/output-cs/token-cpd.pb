þK
TD:\GithubSvn\GitHub\TestCommitGithub\AddWebsiteToIIS\InstallService\ServiceHelper.cs
	namespace 	
InstallService
 
{ 
public 

class 
ServiceHelper 
{ 
public 
static 
void "
InstallAndStartService 1
(1 2
string2 8
servicePath9 D
,D E
stringF L
serviceNameM X
)X Y
{ 	
try 
{ 
ServiceController !
serviceController" 3
=4 5
GetServiceControl6 G
(G H
serviceNameH S
)S T
;T U
if 
( 
serviceController %
==& (
null) -
)- .
{ 
InstallService "
(" #
servicePath# .
,. /
serviceName/ :
): ;
;; <
serviceController %
=& '
GetServiceControl( 9
(9 :
serviceName: E
)E F
;F G
} 
if 
( 
serviceController %
!=& (
null) -
&&. 0
serviceController1 B
.B C
StatusC I
!=J L#
ServiceControllerStatusM d
.d e
Runninge l
)l m
{ 
serviceController %
.% &
Start& +
(+ ,
), -
;- .
serviceController %
.% &
WaitForStatus& 3
(3 4#
ServiceControllerStatus4 K
.K L
RunningL S
,S T
newU X
TimeSpanY a
(a b
$numb c
,c d
$nume f
,f g
$numh i
)i j
)j k
;k l
} 
} 
catch 
( 
	Exception 
ex 
)  
{   
}"" 
}## 	
private%% 
static%% 
ServiceController%% (
GetServiceControl%%) :
(%%: ;
string%%; A
strServiceName%%B P
)%%P Q
{&& 	
ServiceController'' 
['' 
]'' 
services''  (
='') *
ServiceController''+ <
.''< =
GetServices''= H
(''H I
)''I J
;''J K
return)) 
services)) 
.)) 
FirstOrDefault)) *
())* +

controller))+ 5
=>))6 8

controller))9 C
.))C D
ServiceName))D O
.))O P
Equals))P V
())V W
strServiceName))W e
)))e f
)))f g
;))g h
}** 	
private,, 
static,, 
void,, 
InstallService1,, +
(,,+ ,
string,,, 2
servicePath,,3 >
,,,> ?
string,,@ F
serviceName,,G R
),,R S
{-- 	!
ManagedInstallerClass.. !
...! "
InstallHelper.." /
(../ 0
new..0 3
string..4 :
[..: ;
]..; <
{..= >
servicePath..? J
}..K L
)..L M
;..M N
}// 	
private00 
static00 
void00 
InstallService00 *
(00* +
string00+ 1
servicePath002 =
,00= >
string00? E
serviceName00F Q
)00Q R
{11 	
var22 
addArg22 
=22 
$str22 
;22 
if33 
(33 
!33 
string33 
.33 
IsNullOrEmpty33 %
(33% &
serviceName33& 1
)331 2
)332 3
{44 
addArg55 
=55 
$str55 +
+55, -
serviceName55. 9
+55: ;
$str55< A
;55A B
}66 
var77 
installUtilPath77 
=77  !
System77" (
.77( )
Runtime77) 0
.770 1
InteropServices771 @
.77@ A
RuntimeEnvironment77A S
.77S T
GetRuntimeDirectory77T g
(77g h
)77h i
;77i j
var88 
proc88 
=88 
new88 
Process88 "
{99 
	StartInfo:: 
=:: 
{;; 
FileName<< 
=<< 
Path<< #
.<<# $
Combine<<$ +
(<<+ ,
installUtilPath<<, ;
,<<; <
$str<<= N
)<<N O
,<<O P
	Arguments== 
=== 
addArg==  &
+==' (
servicePath==) 4
+==5 6
$str==7 <
,==< =
WindowStyle>> 
=>>  !
ProcessWindowStyle>>" 4
.>>4 5
Hidden>>5 ;
,>>; <"
RedirectStandardOutput?? *
=??+ ,
true??- 1
,??1 2
UseShellExecute@@ #
=@@$ %
false@@& +
}AA 
}BB 
;BB 
procDD 
.DD 
StartDD 
(DD 
)DD 
;DD 
varEE 
resultEE 
=EE 
procEE 
.EE 
StandardOutputEE ,
.EE, -
	ReadToEndEE- 6
(EE6 7
)EE7 8
;EE8 9
procFF 
.FF 
WaitForExitFF 
(FF 
)FF 
;FF 
}GG 	
publicJJ 
staticJJ 
voidJJ 
StopServiceJJ &
(JJ& '
stringJJ' -
servicePathJJ. 9
,JJ9 :
stringJJ; A
serviceNameJJB M
)JJM N
{KK 	
tryLL 
{MM 
ServiceControllerNN !
checkControllerNN" 1
=NN2 3
GetServiceControlNN4 E
(NNE F
serviceNameNNF Q
)NNQ R
;NNR S
ifOO 
(OO 
checkControllerOO #
!=OO$ &
nullOO' +
)OO+ ,
{PP 
ServiceControllerQQ %

controllerQQ& 0
=QQ1 2
newQQ3 6
ServiceControllerQQ7 H
(QQH I
serviceNameQQI T
)QQT U
;QQU V
ifSS 
(SS 
checkControllerSS '
.SS' (
StatusSS( .
!=SS/ 1#
ServiceControllerStatusSS2 I
.SSI J
StoppedSSJ Q
)SSQ R
{TT 

controllerUU "
.UU" #
StopUU# '
(UU' (
)UU( )
;UU) *

controllerVV "
.VV" #
WaitForStatusVV# 0
(VV0 1#
ServiceControllerStatusVV1 H
.VVH I
StoppedVVI P
,VVP Q
newVVR U
TimeSpanVVV ^
(VV^ _
$numVV_ `
,VV` a
$numVVb c
,VVc d
$numVVe f
)VVf g
)VVg h
;VVh i
}WW 
}XX 
UninstallServiceYY  
(YY  !
servicePathYY! ,
,YY, -
serviceNameYY- 8
)YY8 9
;YY9 :
}ZZ 
catch[[ 
([[ 
	Exception[[ 
ex[[ 
)[[  
{\\ 
}^^ 
}__ 	
privateaa 
staticaa 
voidaa 
UninstallService1aa -
(aa- .
stringaa. 4
servicePathaa5 @
)aa@ A
{bb 	!
ManagedInstallerClasscc !
.cc! "
InstallHelpercc" /
(cc/ 0
newcc0 3
stringcc4 :
[cc: ;
]cc; <
{cc= >
$strcc? C
,ccC D
servicePathccE P
}ccQ R
)ccR S
;ccS T
}dd 	
privateee 
staticee 
voidee 
UninstallServiceee ,
(ee, -
stringee- 3
servicePathee4 ?
,ee? @
stringeeA G
serviceNameeeH S
)eeS T
{ff 	
vargg 
addArggg 
=gg 
$strgg 
;gg 
ifhh 
(hh 
!hh 
stringhh 
.hh 
IsNullOrEmptyhh %
(hh% &
serviceNamehh& 1
)hh1 2
)hh2 3
{ii 
addArgjj 
=jj 
$strjj +
+jj, -
serviceNamejj. 9
+jj: ;
$strjj< A
;jjA B
}kk 
varmm 
installUtilPathmm 
=mm  !
Systemmm" (
.mm( )
Runtimemm) 0
.mm0 1
InteropServicesmm1 @
.mm@ A
RuntimeEnvironmentmmA S
.mmS T
GetRuntimeDirectorymmT g
(mmg h
)mmh i
;mmi j
varnn 
procnn 
=nn 
newnn 
Processnn "
{oo 
	StartInfopp 
=pp 
{qq 
FileNamerr 
=rr 
Pathrr #
.rr# $
Combinerr$ +
(rr+ ,
installUtilPathrr, ;
,rr; <
$strrr= N
)rrN O
,rrO P
	Argumentsss 
=ss 
addArgss  &
+ss' (
servicePathss) 4
+ss5 6
$strss7 <
,ss< =
WindowStylett 
=tt  !
ProcessWindowStylett" 4
.tt4 5
Hiddentt5 ;
,tt; <"
RedirectStandardOutputuu *
=uu+ ,
trueuu- 1
,uu1 2
UseShellExecutevv #
=vv$ %
falsevv& +
}ww 
}xx 
;xx 
proczz 
.zz 
Startzz 
(zz 
)zz 
;zz 
proc{{ 
.{{ 
WaitForExit{{ 
({{ 
){{ 
;{{ 
}|| 	
}}} 
}~~ ‰
^D:\GithubSvn\GitHub\TestCommitGithub\AddWebsiteToIIS\InstallService\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str )
)) *
]* +
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
$str +
)+ ,
], -
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
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