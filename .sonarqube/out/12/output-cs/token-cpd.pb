á$
AF:\Projects\UsedCars\UsedCars.API\Configuration\InMemoryConfig.cs
	namespace 	
UsedCars
 
. 
Configuration  
{ 
public 

static 
class 
InMemoryConfig &
{ 
public		 
static		 
IEnumerable		 !
<		! "
IdentityResource		" 2
>		2 3 
GetIdentityResources		4 H
(		H I
)		I J
=>		K M
new


 
List

 
<

 
IdentityResource

 #
>

# $
{	 

new
 
IdentityResources 
.  
OpenId  &
(& '
)' (
,( )
new
 
IdentityResources 
.  
Profile  '
(' (
)( )
}	 

;
 
public 
static 
IEnumerable !
<! "
ApiScope" *
>* +
GetApiScopes, 8
(8 9
)9 :
=>; =
new 
List 
< 
ApiScope 
> 
{  
new! $
ApiScope% -
(- .
$str. 8
)8 9
}: ;
;; <
public 
static 
IEnumerable !
<! "
ApiResource" -
>- .
GetApiResources/ >
(> ?
)? @
=>A C
new 
List 
< 
ApiResource  
>  !
{ 
new 
ApiResource 
(  
$str  *
)* +
{ 
Scopes 
= 
{ 
$str (
}( )
} 
} 
; 
public 
static 
List 
< 
TestUser #
># $
GetUsers% -
(- .
). /
=>0 2
new
 
List 
< 
TestUser 
> 
{
 
new 
TestUser 
{ 
	SubjectId 
= 
$str D
,D E
Username   
=   
$str   #
,  # $
Password!! 
=!! 
$str!! +
,!!+ ,
Claims"" 
="" 
new"" 
List"" #
<""# $
Claim""$ )
>"") *
{## 
new$$ 
Claim$$ 
($$  
$str$$  ,
,$$, -
$str$$. 4
)$$4 5
,$$5 6
new%% 
Claim%% 
(%%  
$str%%  -
,%%- .
$str%%/ 7
)%%7 8
}&& 
}'' 
,'' 
new(( 
TestUser(( 
{)) 
	SubjectId** 
=** 
$str** D
,**D E
Username++ 
=++ 
$str++ #
,++# $
Password,, 
=,, 
$str,, +
,,,+ ,
Claims-- 
=-- 
new-- 
List-- #
<--# $
Claim--$ )
>--) *
{.. 
new// 
Claim// 
(//  
$str//  ,
,//, -
$str//. 4
)//4 5
,//5 6
new00 
Claim00 
(00  
$str00  -
,00- .
$str00/ 8
)008 9
}11 
}22 
}33
 
;33 
public55 
static55 
IEnumerable55 !
<55! "
Client55" (
>55( )

GetClients55* 4
(554 5
)555 6
=>557 9
new66 
List66 
<66 
Client66 
>66 
{77 
new88 
Client88 
{99 
ClientId:: 
=:: 
$str:: -
,::- .
ClientSecrets;; !
=;;" #
new;;$ '
[;;( )
];;) *
{;;+ ,
new;;- 0
Secret;;1 7
(;;7 8
$str;;8 H
.;;H I
Sha512;;I O
(;;O P
);;P Q
);;Q R
};;S T
,;;T U
AllowedGrantTypes<< %
=<<& '

GrantTypes<<( 2
.<<2 35
)ResourceOwnerPasswordAndClientCredentials<<3 \
,<<\ ]
AllowedScopes== !
===" #
{==$ %#
IdentityServerConstants==& =
.=== >
StandardScopes==> L
.==L M
OpenId==M S
,==S T
$str==T ^
}==_ `
}>> 
}?? 
;?? 
}@@ 
}AA Í&
NF:\Projects\UsedCars\UsedCars.API\Controllers\AdditionalEquipmentController.cs
	namespace 	
UsedCars
 
. 
Controllers 
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str $
)$ %
]% &
public 

class )
AdditionalEquipmentController .
:/ 0
ControllerBase1 ?
{ 
private 
readonly '
IAdditionalEquipmentService 4
_additionalService5 G
;G H
public )
AdditionalEquipmentController ,
(, -'
IAdditionalEquipmentService- H
additionalServiceI Z
)Z [
{ 	
_additionalService 
=  
additionalService! 2
??3 5
throw6 ;
new< ?!
ArgumentNullException@ U
(U V
nameofV \
(\ ]
additionalService] n
)n o
)o p
;p q
} 	
[ 	
HttpGet	 
] 
public 
ActionResult 
< 
IEnumerable '
<' ("
AdditionalEquipmentDto( >
>> ?
>? @"
GetAdditionalEquipmentA W
(W X
)X Y
{ 	
var 
equipmentFromRepo !
=" #
_additionalService$ 6
.6 7
GetEquipments7 D
(D E
)E F
;F G
return 
Ok 
( 
equipmentFromRepo '
)' (
;( )
} 	
[ 	
HttpGet	 
( 
$str *
,* +
Name, 0
=1 2
$str3 K
)K L
]L M
public 
IActionResult "
GetAdditionalEquipment 3
(3 4
Guid4 8!
additionalEquipmentId9 N
)N O
{   	
var!! 
	equipment!! 
=!! 
_additionalService!! .
.!!. /
GetEquipment!!/ ;
(!!; <!
additionalEquipmentId!!< Q
)!!Q R
;!!R S
return"" 
Ok"" 
("" 
	equipment"" 
)""  
;""  !
}## 	
[%% 	
HttpGet%%	 
(%% 
$str%% 2
)%%2 3
]%%3 4
public&& 
IActionResult&& !
GetVehicleByEquipment&& 2
(&&2 3
Guid&&3 7!
additionalEquipmentId&&8 M
)&&M N
{'' 	
var(( 
equipmentByVehicle(( "
=((# $
_additionalService((% 7
.((7 8!
GetVehicleByEquipment((8 M
(((M N!
additionalEquipmentId((N c
)((c d
;((d e
return** 
Ok** 
(** 
equipmentByVehicle** (
)**( )
;**) *
}++ 	
[-- 	
HttpGet--	 
(-- 
$str-- 2
)--2 3
]--3 4
public.. 
IActionResult.. +
GetAdditionalEquipmentByVehicle.. <
(..< =
Guid..= A
	vehicleId..B K
)..K L
{// 	
var00 
vehicleByEquipment00 "
=00# $
_additionalService00% 7
.007 8!
GetEquipmentByVehicle008 M
(00M N
	vehicleId00N W
)00W X
;00X Y
return11 
Ok11 
(11 
vehicleByEquipment11 (
)11( )
;11) *
}22 	
[33 	
HttpPost33	 
]33 
[55 	
HttpPost55	 
]55 
public66 
ActionResult66 %
CreateAdditionalEquipment66 5
(665 6
[666 7
FromBody667 ?
]66? @"
AdditionalEquipmentDto66A W(
additionalEquipmentDtoCreate66X t
)66t u
{77 	
var88 
	equipment88 
=88 
_additionalService88 .
.88. /
CreateEquipment88/ >
(88> ?(
additionalEquipmentDtoCreate88? [
)88[ \
;88\ ]
return:: 
Ok:: 
(:: 
	equipment:: 
)::  
;::  !
};; 	
[== 	

HttpDelete==	 
(== 
$str== -
)==- .
]==. /
public>> 
ActionResult>> 
DeleteEquipment>> +
(>>+ ,
Guid>>, 0!
additionalEquipmentId>>1 F
)>>F G
{?? 	
var@@ 
equipmentToDelete@@ !
=@@" #
_additionalService@@$ 6
.@@6 7
DeleteEquipment@@7 F
(@@F G!
additionalEquipmentId@@G \
)@@\ ]
;@@] ^
returnAA 
OkAA 
(AA 
equipmentToDeleteAA '
)AA' (
;AA( )
}CC 	
}DD 
}EE «!
CF:\Projects\UsedCars\UsedCars.API\Controllers\CategoryController.cs
	namespace		 	
UsedCars		
 
.		 
Controllers		 
{

 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
CategoryController #
:$ %
ControllerBase& 4
{ 
private 
readonly 
ICategoryService )
_categoryService* :
;: ;
public 
CategoryController !
(! "
ICategoryService" 2
categoryService3 B
)B C
{ 	
_categoryService 
= 
categoryService .
??/ 1
throw2 7
new8 ;!
ArgumentNullException< Q
(Q R
nameofR X
(X Y
categoryServiceY h
)h i
)i j
;j k
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
IEnumerable' 2
<2 3
CategoryDto3 >
>> ?
>? @
>@ A
GetCategoriesB O
(O P
)P Q
{ 	
var 
categoriesToReturn "
=# $
await% *
_categoryService+ ;
.; <
GetCategories< I
(I J
)J K
;K L
return 
Ok 
( 
categoriesToReturn (
)( )
;) *
} 	
[ 	
HttpGet	 
( 
$str 
,  
Name! %
=% &
$str& 3
)3 4
]4 5
public 
async 
Task 
< 
IActionResult '
>' (
GetCategory) 4
(4 5
Guid5 9

categoryId: D
)D E
{ 	
var 
category 
= 
await  
_categoryService! 1
.1 2
GetCategory2 =
(= >

categoryId> H
)H I
;I J
if 
( 
category 
== 
null 
) 
{   
return!! 
NotFound!! 
(!!  
)!!  !
;!!! "
}"" 
return## 
Ok## 
(## 
category## 
)## 
;##  
}$$ 	
[%% 	
HttpPost%%	 
]%% 
[&& 	 
ProducesResponseType&&	 
(&& 
$num&& !
)&&! "
]&&" #
['' 	 
ProducesResponseType''	 
('' 
$num'' !
)''! "
]''" #
public(( 
ActionResult(( 
CreateCategory(( *
(((* +
[((+ ,
FromBody((, 4
]((4 5
CategoryDto((6 A
categoryCreate((B P
)((P Q
{)) 	
var** 
categoryToReturn**  
=**! "
_categoryService**# 3
.**3 4
CreateCategory**4 B
(**B C
categoryCreate**C Q
)**Q R
;**R S
return++ 
Ok++ 
(++ 
categoryToReturn++ &
)++& '
;++' (
},, 	
[.. 	

HttpDelete..	 
(.. 
$str.. "
).." #
]..# $
public// 
ActionResult// 
DeleteCategory// *
(//* +
Guid//+ /

categoryId//0 :
)//: ;
{00 	
var11 
categoryFromRepo11  
=11! "
_categoryService11# 3
.113 4
DeleteCategory114 B
(11B C

categoryId11C M
)11M N
;11N O
if33 
(33 
categoryFromRepo33  
==33  "
null33" &
)33& '
{44 
return55 
NotFound55 
(55  
)55  !
;55! "
}66 
return88 
	NoContent88 
(88 
)88 
;88 
}:: 	
}<< 
}== ´
?F:\Projects\UsedCars\UsedCars.API\Controllers\MakeController.cs
	namespace 	
UsedCars
 
. 
Controllers 
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
MakeController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IMakeService %
_makeService& 2
;2 3
public 
MakeController 
( 
IMakeService *
makeService+ 6
)6 7
{ 	
_makeService 
= 
makeService &
??' )
throw* /
new0 3!
ArgumentNullException4 I
(I J
nameofJ P
(P Q
makeServiceQ \
)\ ]
)] ^
;^ _
} 	
[ 	
HttpGet	 
] 
public 
ActionResult 
< 
IEnumerable '
<' (
MakeDto( /
>/ 0
>0 1
GetMakes2 :
(: ;
); <
{ 	
var 
makesFromRepo 
= 
_makeService  ,
., -
GetMakes- 5
(5 6
)6 7
;7 8
return 
Ok 
( 
makesFromRepo #
)# $
;$ %
} 	
[ 	
HttpGet	 
( 
$str 
, 
Name !
=" #
$str$ -
)- .
]. /
public 
IActionResult 
GetMake $
($ %
Guid% )
makeId* 0
)0 1
{   	
var!! 
make!! 
=!! 
_makeService!! #
.!!# $
GetMake!!$ +
(!!+ ,
makeId!!, 2
)!!2 3
;!!3 4
return"" 
Ok"" 
("" 
make"" 
)"" 
;"" 
}## 	
[%% 	
HttpPost%%	 
]%% 
public&& 
ActionResult&& 

CreateMake&& &
(&&& '
[&&' (
FromBody&&( 0
]&&0 1
MakeDto&&2 9

createMake&&: D
)&&D E
{'' 	
var(( 
makeToReturn(( 
=(( 
_makeService(( +
.((+ ,

CreateMake((, 6
(((6 7

createMake((7 A
)((A B
;((B C
return** 
Ok** 
(** 
makeToReturn** "
)**" #
;**# $
},, 	
[// 	

HttpDelete//	 
(// 
$str// 
)// 
]//  
public00 
ActionResult00 

DeleteMake00 &
(00& '
Guid00' +
makeId00, 2
)002 3
{11 	
_makeService22 
.22 

DeleteMake22 #
(22# $
makeId22$ *
)22* +
;22+ ,
return44 
	NoContent44 
(44 
)44 
;44 
}55 	
}77 
}88 „
@F:\Projects\UsedCars\UsedCars.API\Controllers\ModelController.cs
	namespace 	
UsedCars
 
. 
Controllers 
{		 
[

 
Route

 

(


 
$str

 
)

 
]

 
[ 
ApiController 
] 
public 

class 
ModelController  
:! "
ControllerBase# 1
{ 
private 
readonly 
IModelService &
_modelService' 4
;4 5
public 
ModelController 
( 
IModelService ,
modelService- 9
)9 :
{ 	
_modelService 
= 
modelService (
??) +
throw, 1
new2 5!
ArgumentNullException6 K
(K L
nameofL R
(R S
modelServiceS _
)_ `
)` a
;a b
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
ActionResult '
>' (
	GetModels) 2
(2 3
)3 4
{ 	
var 
modelsToReturn 
=  
await! &
_modelService' 4
.4 5
	GetModels5 >
(> ?
)? @
;@ A
return 
Ok 
( 
modelsToReturn $
)$ %
;% &
} 	
[ 	
HttpGet	 
( 
$str 
, 
Name "
=# $
$str% /
)/ 0
]0 1
public 
async 
Task 
< 
IActionResult '
>' (
GetModel) 1
(1 2
Guid2 6
modelId7 >
)> ?
{ 	
var   
modelToReturn   
=   
await   $
_modelService  % 2
.  2 3
GetModel  3 ;
(  ; <
modelId  < C
)  C D
;  D E
return!! 
Ok!! 
(!! 
modelToReturn!! #
)!!# $
;!!$ %
}"" 	
[$$ 	
HttpPost$$	 
]$$ 
public%% 
async%% 
Task%% 
<%% 
ActionResult%% &
<%%& '
MakeDto%%' .
>%%. /
>%%/ 0
CreateModel%%1 <
(%%< =
[%%= >
FromBody%%> F
]%%F G
MakeDto%%H O
modelCreate%%P [
)%%[ \
{&& 	
var'' 
modelToReturn'' 
='' 
await''  %
_modelService''& 3
.''3 4
CreateModel''4 ?
(''? @
modelCreate''@ K
)''K L
;''L M
return)) 
Ok)) 
()) 
modelToReturn)) #
)))# $
;))$ %
}** 	
[.. 	

HttpDelete..	 
(.. 
$str..  
)..  !
]..! "
public// 
ActionResult// 
DeleteModel// '
(//' (
Guid//( ,
modelId//- 4
)//4 5
{00 	
var11 
modelToDelete11 
=11 
_modelService11  -
.11- .
DeleteModel11. 9
(119 :
modelId11: A
)11A B
;11B C
return22 
	NoContent22 
(22 
)22 
;22 
}44 	
}66 
}77 …8
BF:\Projects\UsedCars\UsedCars.API\Controllers\VehicleController.cs
	namespace

 	
UsedCars


 
.

 
Controllers

 
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
VehicleController "
:# $
ControllerBase% 3
{ 
private 
readonly 
IVehicleService (
_vehicleService) 8
;8 9
public 
VehicleController  
(  !
IVehicleService! 0
vehicleService1 ?
)? @
{ 	
_vehicleService 
= 
vehicleService +
??, .
throw/ 4
new5 8!
ArgumentNullException9 N
(N O
nameofO U
(U V
vehicleServiceV d
)d e
)e f
;f g
} 	
[ 	
HttpGet	 
] 
[ 	 
ProducesResponseType	 
( 
$num !
)! "
]" #
[ 	 
ProducesResponseType	 
( 
$num !
)! "
]" #
[ 	
LimitRequests	 
( 
MaxRequests "
=# $
$num% &
,& '

TimeWindow( 2
=3 4
$num5 6
)6 7
]7 8
public 
async 
Task 
< 
ActionResult &
>& '
GetVehiclesAsync( 8
(8 9
)9 :
{ 	
var 
claims 
= 
User 
. 
Claims $
;$ %
var 
vehiclesToReturn  
=! "
await# (
_vehicleService) 8
.8 9
GetAllVehicles9 G
(G H
)H I
;I J
return 
Ok 
( 
vehiclesToReturn &
)& '
;' (
} 	
[!! 	
HttpGet!!	 
(!! 
$str!! 
,!! 
Name!!  $
=!!% &
$str!!' 3
)!!3 4
]!!4 5
["" 	 
ProducesResponseType""	 
("" 
$num"" !
)""! "
]""" #
[## 	 
ProducesResponseType##	 
(## 
$num## !
)##! "
]##" #
public$$ 
async$$ 
Task$$ 
<$$ 
ActionResult$$ &
>$$& '
GetVehicleAsync$$( 7
($$7 8
Guid$$8 <
	vehicleId$$= F
)$$F G
{%% 	
var&& 
vehicleFromRepo&& 
=&&  !
await&&" '
_vehicleService&&( 7
.&&7 8

GetVehicle&&8 B
(&&B C
	vehicleId&&C L
)&&L M
;&&M N
return(( 
Ok(( 
((( 
vehicleFromRepo(( %
)((% &
;((& '
})) 	
[++ 	
HttpPost++	 
]++ 
public,, 
async,, 
Task,, 
<,, 
ActionResult,, &
>,,& '
CreateVehicleAsync,,( :
(,,: ;
[,,; <
FromBody,,< D
],,D E

VehicleDto,,F P

vehicleDto,,Q [
),,[ \
{-- 	
var.. 
vehicleToCreate.. 
=..  !
await.." '
_vehicleService..( 7
...7 8
CreateVehicleAsync..8 J
(..J K

vehicleDto..K U
)..U V
;..V W
return// 
CreatedAtRoute// !
(//! "
$str//" .
,//. /
new00 
{00 
	vehicleId00 
=00  
vehicleToCreate00! 0
.000 1
Id001 3
}004 5
,005 6
vehicleToCreate11 
)11  
;11  !
}22 	
[44 	
HttpPut44	 
(44 
$str44 
)44 
]44  
[55 	 
ProducesResponseType55	 
(55 
$num55 !
)55! "
]55" #
[66 	 
ProducesResponseType66	 
(66 
$num66 !
)66! "
]66" #
public77 
async77 
Task77 
<77 
IActionResult77 '
>77' (
UpdateVehicleAsync77) ;
(77; <
Guid77< @
	vehicleId77A J
,77J K
[77L M
FromBody77M U
]77U V

VehicleDto77W a
vehicle77b i
)77i j
{88 	
if99 
(99 
vehicle99 
==99 
null99 
||99  "
vehicle99# *
.99* +
Id99+ -
!=99. 0
	vehicleId991 :
)99: ;
{:: 
return;; 

BadRequest;; !
(;;! "
);;" #
;;;# $
}<< 
var>> 
updatedVehicle>> 
=>>  
await>>! &
_vehicleService>>' 6
.>>6 7
UpdateVehicle>>7 D
(>>D E
vehicle>>E L
)>>L M
;>>M N
if@@ 
(@@ 
updatedVehicle@@ 
==@@ !
null@@" &
)@@& '
{AA 
returnBB 

BadRequestBB !
(BB! "
)BB" #
;BB# $
}CC 
returnEE 
	NoContentEE 
(EE 
)EE 
;EE 
}GG 	
[II 	
	HttpPatchII	 
(II 
$strII  
)II  !
]II! "
[JJ 	 
ProducesResponseTypeJJ	 
(JJ 
$numJJ !
)JJ! "
]JJ" #
[KK 	 
ProducesResponseTypeKK	 
(KK 
$numKK !
)KK! "
]KK" #
publicLL 
asyncLL 
TaskLL 
<LL 
ActionResultLL &
>LL& ''
PartiallyUpdateVehicleAsyncLL( C
(LLC D
GuidLLD H
	vehicleIdLLI R
,LLR S
[MM 
FromBodyMM 
]MM 
JsonPatchDocumentMM (
<MM( )

VehicleDtoMM) 3
>MM3 4
patchDocumentMM5 B
)MMB C
{NN 	
awaitOO 
_vehicleServiceOO  
.OO  !
PatchVehicleOO! -
(OO- .
	vehicleIdOO. 7
,OO7 8
patchDocumentOO8 E
)OOE F
;OOF G
returnRR 
	NoContentRR 
(RR 
)RR 
;RR 
}SS 	
[UU 	

HttpDeleteUU	 
(UU 
$strUU !
)UU! "
]UU" #
publicVV 
asyncVV 
TaskVV 
<VV 
ActionResultVV &
>VV& '
DeleteVehicleAsyncVV( :
(VV: ;
GuidVV; ?
	vehicleIdVV@ I
)VVI J
{WW 	
varXX 
vehicleFromRepoXX 
=XX  !
_vehicleServiceXX" 1
.XX1 2
DeleteVehicleXX2 ?
(XX? @
	vehicleIdXX@ I
)XXI J
;XXJ K
returnZZ 
	NoContentZZ 
(ZZ 
)ZZ 
;ZZ 
}\\ 	
}^^ 
}__ ¡6
IF:\Projects\UsedCars\UsedCars.API\CustomMiddleWare\RateLimitMiddleware.cs
	namespace 	
UsedCars
 
. 
CustomMiddleWare #
{ 
public 

class 
RateLimitMiddleware $
{		 
private

 
readonly

 
RequestDelegate

 (
_next

) .
;

. /
private 
readonly 
IDistributedCache *
_cache+ 1
;1 2
public 
RateLimitMiddleware "
(" #
RequestDelegate# 2
next3 7
,7 8
IDistributedCache9 J
cacheK P
)P Q
{ 	
_next 
= 
next 
; 
_cache 
= 
cache 
; 
} 	
public 
async 
Task 
InvokeAsync %
(% &
HttpContext& 1
context2 9
)9 :
{ 	
var 
endpoint 
= 
context "
." #
GetEndpoint# .
(. /
)/ 0
;0 1
var !
rateLimitingDecorator %
=& '
endpoint( 0
?0 1
.1 2
Metadata2 :
.: ;
GetMetadata; F
<F G
LimitRequestsG T
>T U
(U V
)V W
;W X
if 
( !
rateLimitingDecorator %
is& (
null) -
)- .
{ 
await 
_next 
( 
context #
)# $
;$ %
return 
; 
} 
var 
key 
= 
GenerateClientKey '
(' (
context( /
)/ 0
;0 1
var 
clientStatistics  
=! "
await# ($
GetClientStatisticsByKey) A
(A B
keyB E
)E F
;F G
if!! 
(!! 
clientStatistics!!  
!=!!! #
null!!$ (
&&!!) +
DateTime"" 
."" 
UtcNow"" 
<""  !
clientStatistics""" 2
.""2 3&
LastSuccessfulResponseTime""3 M
.""M N

AddSeconds""N X
(""X Y!
rateLimitingDecorator""Y n
.""n o

TimeWindow""o y
)""y z
&&""{ }
clientStatistics##  
.##  !1
%NumberOfRequestsCompletedSuccessfully##! F
==##G I!
rateLimitingDecorator##J _
.##_ `
MaxRequests##` k
)##k l
{$$ 
context%% 
.%% 
Response%%  
.%%  !

StatusCode%%! +
=%%, -
(%%. /
int%%/ 2
)%%2 3
HttpStatusCode%%3 A
.%%A B
TooManyRequests%%B Q
;%%Q R
return&& 
;&& 
}'' 
await)) )
UpdateClientStatisticsStorage)) /
())/ 0
key))0 3
,))3 4!
rateLimitingDecorator))5 J
.))J K
MaxRequests))K V
)))V W
;))W X
await** 
_next** 
(** 
context** 
)**  
;**  !
}++ 	
private-- 
static-- 
string-- 
GenerateClientKey-- /
(--/ 0
HttpContext--0 ;
context--< C
)--C D
=>--E G
$"--H J
{--J K
context--K R
.--R S
Request--S Z
.--Z [
Path--[ _
}--_ `
$str--` a
{--a b
context--b i
.--i j

Connection--j t
.--t u
RemoteIpAddress	--u Ñ
}
--Ñ Ö
"
--Ö Ü
;
--Ü á
private// 
async// 
Task// 
<// 
ClientStatistics// +
>//+ ,$
GetClientStatisticsByKey//- E
(//E F
string//F L
key//M P
)//P Q
=>//R T
await//U Z
_cache//[ a
.//a b
GetCacheValueAsync//b t
<//t u
ClientStatistics	//u Ö
>
//Ö Ü
(
//Ü á
key
//á ä
)
//ä ã
;
//ã å
public11 
class11 
ClientStatistics11 %
{22 	
public33 
DateTime33 &
LastSuccessfulResponseTime33 6
{337 8
get339 <
;33< =
set33> A
;33A B
}33C D
public44 
int44 1
%NumberOfRequestsCompletedSuccessfully44 <
{44= >
get44? B
;44B C
set44D G
;44G H
}44I J
}55 	
private77 
async77 
Task77 )
UpdateClientStatisticsStorage77 8
(778 9
string779 ?
key77@ C
,77C D
int77E H
maxRequests77I T
)77T U
{88 	
var99 

clientStat99 
=99 
await99 "
_cache99# )
.99) *
GetCacheValueAsync99* <
<99< =
ClientStatistics99= M
>99M N
(99N O
key99O R
)99R S
;99S T
if;; 
(;; 

clientStat;; 
!=;; 
null;; "
);;" #
{<< 

clientStat== 
.== &
LastSuccessfulResponseTime== 5
===6 7
DateTime==8 @
.==@ A
UtcNow==A G
;==G H
if?? 
(?? 

clientStat?? 
.?? 1
%NumberOfRequestsCompletedSuccessfully?? D
==??E G
maxRequests??H S
)??S T

clientStat@@ 
.@@ 1
%NumberOfRequestsCompletedSuccessfully@@ D
=@@E F
$num@@G H
;@@H I
elseBB 

clientStatCC 
.CC 1
%NumberOfRequestsCompletedSuccessfullyCC D
++CCD F
;CCF G
awaitEE 
_cacheEE 
.EE 
SetCacheValueAsyncEE /
<EE/ 0
ClientStatisticsEE0 @
>EE@ A
(EEA B
keyEEB E
,EEE F

clientStatEEG Q
)EEQ R
;EER S
}FF 
elseGG 
{HH 
varII 
clientStatisticsII $
=II% &
newII' *
ClientStatisticsII+ ;
{JJ &
LastSuccessfulResponseTimeKK .
=KK/ 0
DateTimeKK1 9
.KK9 :
UtcNowKK: @
,KK@ A1
%NumberOfRequestsCompletedSuccessfullyLL 9
=LL: ;
$numLL< =
}MM 
;MM 
awaitOO 
_cacheOO 
.OO 
SetCacheValueAsyncOO /
<OO/ 0
ClientStatisticsOO0 @
>OO@ A
(OOA B
keyOOB E
,OOE F
clientStatisticsOOG W
)OOW X
;OOX Y
}PP 
}QQ 	
}RR 
}SS Å
=F:\Projects\UsedCars\UsedCars.API\Decorators\LimitRequests.cs
	namespace 	
UsedCars
 
. 

Decorators 
{ 
[ 
AttributeUsage 
( 
AttributeTargets $
.$ %
Method% +
)+ ,
], -
public 

class 
LimitRequests 
: 
	Attribute  )
{ 
public 
int 

TimeWindow 
{ 
get  #
;# $
set% (
;( )
}* +
public 
int 
MaxRequests 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 ã
MF:\Projects\UsedCars\UsedCars.API\Extensions\DistributingCachingExtensions.cs
	namespace 	
UsedCars
 
. 

Extensions 
{ 
public 

static 
class )
DistributingCachingExtensions 5
{ 
public 
async 
static 
Task  
SetCacheValueAsync! 3
<3 4
T4 5
>5 6
(6 7
this7 ;
IDistributedCache< M
distributedCacheN ^
,^ _
string		 
key		 
,		 
T		 
value		 
,		  
CancellationToken

 
token

 #
=

$ %
default

& -
(

- .
CancellationToken

. ?
)

? @
)

@ A
{ 	
await 
distributedCache "
." #
SetAsync# +
(+ ,
key, /
,/ 0
value1 6
.6 7
ToByteArray7 B
(B C
)C D
,D E
tokenF K
)K L
;L M
} 	
public 
async 
static 
Task  
<  !
T! "
>" #
GetCacheValueAsync$ 6
<6 7
T7 8
>8 9
(9 :
this: >
IDistributedCache? P
distributedCacheQ a
,a b
string 
key 
, 
CancellationToken 
token #
=$ %
default& -
(- .
CancellationToken. ?
)? @
)@ A
whereB G
TH I
:J K
classL Q
{ 	
var 
result 
= 
await 
distributedCache /
./ 0
GetAsync0 8
(8 9
key9 <
,< =
token> C
)C D
;D E
return 
result 
. 
FromByteArray '
<' (
T( )
>) *
(* +
)+ ,
;, -
} 	
} 
} ÷
DF:\Projects\UsedCars\UsedCars.API\Extensions\MiddlewareExtensions.cs
	namespace 	
UsedCars
 
. 

Extensions 
{ 
public 

static 
class  
MiddlewareExtensions ,
{ 
public 
static 
IApplicationBuilder )
UseRateLimiting* 9
(9 :
this: >
IApplicationBuilder? R
builderS Z
)Z [
{ 	
return		 
builder		 
.		 
UseMiddleware		 (
<		( )
RateLimitMiddleware		) <
>		< =
(		= >
)		> ?
;		? @
}

 	
} 
} ú
=F:\Projects\UsedCars\UsedCars.API\Extensions\Serialization.cs
	namespace 	
UsedCars
 
. 

Extensions 
{ 
public 

static 
class 
Serialization %
{ 
public		 
static		 
byte		 
[		 
]		 
ToByteArray		 (
(		( )
this		) -
object		. 4
objectToSerialize		5 F
)		F G
{

 	
if 
( 
objectToSerialize !
==" $
null% )
)) *
{ 
return 
null 
; 
} 
return 
Encoding 
. 
Default #
.# $
GetBytes$ ,
(, -
JsonConvert- 8
.8 9
SerializeObject9 H
(H I
objectToSerializeI Z
)Z [
)[ \
;\ ]
} 	
public 
static 
T 
FromByteArray %
<% &
T& '
>' (
(( )
this) -
byte. 2
[2 3
]3 4
arrayToDeserialize5 G
)G H
whereI N
TO P
:Q R
classS X
{ 	
if 
( 
arrayToDeserialize "
==# %
null& *
)* +
{ 
return 
default 
( 
T  
)  !
;! "
} 
return 
JsonConvert 
. 
DeserializeObject 0
<0 1
T1 2
>2 3
(3 4
Encoding4 <
.< =
Default= D
.D E
	GetStringE N
(N O
arrayToDeserializeO a
)a b
)b c
;c d
} 	
} 
} Ü0
,F:\Projects\UsedCars\UsedCars.API\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. 
AddControllers 
(  
)  !
.! "
AddNewtonsoftJson" 3
(3 4
setupAction4 ?
=>@ B
{ 
setupAction 
. 
SerializerSettings "
." #
ContractResolver# 3
=4 5
new 
2
&CamelCasePropertyNamesContractResolver 1
(1 2
)2 3
;3 4
} 
) 
; 
builder 
. 
Services 
. 
AddIdentityServer "
(" #
)# $
.  
AddInMemoryApiScopes %
(% &
InMemoryConfig& 4
.4 5
GetApiScopes5 A
(A B
)B C
)C D
. #
AddInMemoryApiResources (
(( )
InMemoryConfig) 7
.7 8
GetApiResources8 G
(G H
)H I
)I J
. (
AddInMemoryIdentityResources -
(- .
InMemoryConfig. <
.< = 
GetIdentityResources= Q
(Q R
)R S
)S T
. 
AddTestUsers 
( 
InMemoryConfig ,
., -
GetUsers- 5
(5 6
)6 7
)7 8
. 
AddInMemoryClients #
(# $
InMemoryConfig$ 2
.2 3

GetClients3 =
(= >
)> ?
)? @
. )
AddDeveloperSigningCredential .
(. /
)/ 0
;0 1
builder 
. 
Services 
. 
AddAuthentication "
(" #
$str# +
)+ ,
.   
AddJwtBearer   
(   
$str   &
,  & '
opt  ( +
=>  , .
{!! 
opt"" 
.""  
RequireHttpsMetadata"" ,
=""- .
false""/ 4
;""4 5
opt## 
.## 
	Authority## !
=##" #
$str##$ <
;##< =
opt$$ 
.$$ 
Audience$$  
=$$! "
$str$$# -
;$$- .
}%% 
)%% 
;%% 
builder'' 
.'' 
Services'' 
.'' %
AddDistributedMemoryCache'' *
(''* +
)''+ ,
;'', -
builder(( 
.(( 
Services(( 
.(( 
AddAutoMapper(( 
((( 
	AppDomain(( (
.((( )
CurrentDomain(() 6
.((6 7
GetAssemblies((7 D
(((D E
)((E F
)((F G
;((G H
builder)) 
.)) 
Services)) 
.)) 
AddAutoMapper)) 
()) 
typeof)) %
())% &
VehicleProfile))& 4
)))4 5
)))5 6
;))6 7
builder** 
.** 
Services** 
.** 
RegisterServices** !
(**! "
)**" #
;**# $
builder,, 
.,, 
Services,, 
.,, #
AddEndpointsApiExplorer,, (
(,,( )
),,) *
;,,* +
builder-- 
.-- 
Services-- 
.-- 
AddSwaggerGen-- 
(-- 
)--  
;--  !
var.. 
dbConnectionString.. 
=.. 
builder..  
...  !
Configuration..! .
.... /
GetConnectionString../ B
(..B C
$str..C W
)..W X
;..X Y
builder// 
.// 
Services// 
.// 
AddDbContext// 
<// 
UsedCarsContext// -
>//- .
(//. /
options/// 6
=>//7 9
options//: A
.//A B
UseSqlServer//B N
(//N O
dbConnectionString//O a
)//a b
)//b c
;//c d
var11 
app11 
=11 	
builder11
 
.11 
Build11 
(11 
)11 
;11 
if44 
(44 
app44 
.44 
Environment44 
.44 
IsDevelopment44 !
(44! "
)44" #
)44# $
{55 
app66 
.66 

UseSwagger66 
(66 
)66 
;66 
app77 
.77 
UseSwaggerUI77 
(77 
)77 
;77 
}88 
app99 
.99 
UseStaticFiles99 
(99 
)99 
;99 
app:: 
.:: 

UseRouting:: 
(:: 
):: 
;:: 
app;; 
.;; 
UseIdentityServer;; 
(;; 
);; 
;;; 
app== 
.== 
UseHttpsRedirection== 
(== 
)== 
;== 
app>> 
.>> 
UseRateLimiting>> 
(>> 
)>> 
;>> 
app@@ 
.@@ 
UseAuthentication@@ 
(@@ 
)@@ 
;@@ 
appAA 
.AA 
UseAuthorizationAA 
(AA 
)AA 
;AA 
appBB 
.BB 
UseEndpointsBB 
(BB 
	endpointsBB 
=>BB 
{CC 
	endpointsDD 
.DD %
MapDefaultControllerRouteDD '
(DD' (
)DD( )
;DD) *
}EE 
)EE 
;EE 
appFF 
.FF 
MapControllersFF 
(FF 
)FF 
;FF 
appHH 
.HH 
RunHH 
(HH 
)HH 	
;HH	 
