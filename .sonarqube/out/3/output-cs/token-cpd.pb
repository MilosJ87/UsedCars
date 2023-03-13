§4
XF:\Projects\UsedCars\UsedCars.Services\AdditionalEquipment\AdditionalEquipmentService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

class &
AdditionalEquipmentService +
:, -'
IAdditionalEquipmentService. I
{ 
private 
readonly 
IAdditionalService +$
_additionalEquipmentRepo, D
;D E
private 
readonly 
IMapper  
_mapper! (
;( )
public &
AdditionalEquipmentService )
() *
IAdditionalService* <#
additionalEquipmentRepo= T
,T U
IMapperV ]
mapper^ d
)d e
{ 	$
_additionalEquipmentRepo $
=% &#
additionalEquipmentRepo' >
??? A
throwB G
newH K!
ArgumentNullExceptionL a
(a b
nameofb h
(h i$
additionalEquipmentRepo	i Ä
)
Ä Å
)
Å Ç
;
Ç É
_mapper 
= 
mapper 
?? 
throw  %
new& )!
ArgumentNullException* ?
(? @
nameof@ F
(F G
mapperG M
)M N
)N O
;O P
} 	
public 
async 
Task 
< 
IEnumerable %
<% &"
AdditionalEquipmentDto& <
>< =
>= >
GetEquipments? L
(L M
)M N
{ 	
var 

equipments 
= 
await "$
_additionalEquipmentRepo# ;
.; <
GetAllAsync< G
(G H
)H I
;I J
var 
equipmentsToReturn "
= 
_mapper 
. 
Map 
< 
IEnumerable )
<) *"
AdditionalEquipmentDto* @
>@ A
>A B
(B C

equipmentsC M
)M N
;N O
return 
equipmentsToReturn %
;% &
} 	
public!! 
async!! 
Task!! 
<!! "
AdditionalEquipmentDto!! 0
>!!0 1
GetEquipment!!2 >
(!!> ?
Guid!!? C!
additionalEquipmentId!!D Y
)!!Y Z
{"" 	
var## 

equipments## 
=## 
await## "$
_additionalEquipmentRepo### ;
.##; <
GetById##< C
(##C D!
additionalEquipmentId##D Y
)##Y Z
;##Z [
var$$ 
equipmentToReturn$$ !
=$$" #
_mapper$$$ +
.$$+ ,
Map$$, /
<$$/ 0"
AdditionalEquipmentDto$$0 F
>$$F G
($$G H

equipments$$H R
)$$R S
;$$S T
return%% 
equipmentToReturn%% $
;%%$ %
}&& 	
public(( 
async(( 
Task(( 
<(( "
AdditionalEquipmentDto(( 0
>((0 1
CreateEquipment((2 A
(((A B"
AdditionalEquipmentDto((B X"
additionalEquipmentDto((Y o
)((o p
{)) 	
var** 
equipemntToCreate** !
=**" #
_mapper**$ +
.**+ ,
Map**, /
<**/ 0
Entities**0 8
.**8 9
AdditionalEquipment**9 L
>**L M
(**M N"
additionalEquipmentDto**N d
)**d e
;**e f
await++ $
_additionalEquipmentRepo++ *
.++* +
InsertAsync+++ 6
(++6 7
equipemntToCreate++7 H
)++H I
;++I J
await,, $
_additionalEquipmentRepo,, *
.,,* +
	SaveAsync,,+ 4
(,,4 5
),,5 6
;,,6 7
var-- 
equipmentToReturn-- !
=--" #
_mapper--$ +
.--+ ,
Map--, /
<--/ 0"
AdditionalEquipmentDto--0 F
>--F G
(--G H
equipemntToCreate--H Y
)--Y Z
;--Z [
return.. 
equipmentToReturn.. $
;..$ %
}00 	
public22 
async22 
Task22 
<22 "
AdditionalEquipmentDto22 0
>220 1!
GetVehicleByEquipment222 G
(22G H
Guid22H L!
additionalEquipmentId22M b
)22b c
{33 	
var44 
	equipment44 
=44 $
_additionalEquipmentRepo44 5
.445 6!
GetVehicleByEquipment446 K
(44K L!
additionalEquipmentId44L a
)44a b
.44b c
FirstOrDefault44c q
(44q r
)44r s
;44s t
var55 
equipmentToReturn55 !
=55" #
_mapper55$ +
.55+ ,
Map55, /
<55/ 0"
AdditionalEquipmentDto550 F
>55F G
(55G H
	equipment55H Q
)55Q R
;55R S
return77 
equipmentToReturn77 $
;77$ %
}88 	
public:: 
async:: 
Task:: 
<:: 

VehicleDto:: $
>::$ %!
GetEquipmentByVehicle::& ;
(::; <
Guid::< @
	vehicleId::A J
)::J K
{;; 	
var<< 
vehicle<< 
=<< $
_additionalEquipmentRepo<< 2
.<<2 3!
GetEquipmentByVehicle<<3 H
(<<H I
	vehicleId<<I R
)<<R S
;<<S T
var== 
vehicleToReturn== 
===  !
_mapper==" )
.==) *
Map==* -
<==- .

VehicleDto==. 8
>==8 9
(==9 :
vehicle==: A
)==A B
;==B C
return?? 
vehicleToReturn?? "
;??" #
}@@ 	
publicAA 
asyncAA 
TaskAA 
DeleteEquipmentAA )
(AA) *
GuidAA* .
equipmentIdAA/ :
)AA: ;
{BB 	
varCC 
equipmentToDeleteCC !
=CC" #
awaitCC$ )$
_additionalEquipmentRepoCC* B
.CCB C
GetByIdCCC J
(CCJ K
equipmentIdCCK V
)CCV W
;CCW X
varDD 
deleteEquipmentDD 
=DD  !
awaitDD" '$
_additionalEquipmentRepoDD( @
.DD@ A
DeleteDDA G
(DDG H
equipmentToDeleteDDH Y
)DDY Z
;DDZ [
awaitEE $
_additionalEquipmentRepoEE *
.EE* +
	SaveAsyncEE+ 4
(EE4 5
)EE5 6
;EE6 7
}GG 	
}HH 
}II ·
YF:\Projects\UsedCars\UsedCars.Services\AdditionalEquipment\IAdditionalEquipmentService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

	interface '
IAdditionalEquipmentService 0
{ 
Task 
< "
AdditionalEquipmentDto #
># $
CreateEquipment% 4
(4 5"
AdditionalEquipmentDto5 K"
additionalEquipmentDtoL b
)b c
;c d
Task 
DeleteEquipment 
( 
Guid !
equipmentId" -
)- .
;. /
Task		 
<		 "
AdditionalEquipmentDto		 #
>		# $
GetEquipment		% 1
(		1 2
Guid		2 6!
additionalEquipmentId		7 L
)		L M
;		M N
Task

 
<

 

VehicleDto

 
>

 !
GetEquipmentByVehicle

 .
(

. /
Guid

/ 3
	vehicleId

4 =
)

= >
;

> ?
Task 
< 
IEnumerable 
< "
AdditionalEquipmentDto /
>/ 0
>0 1
GetEquipments2 ?
(? @
)@ A
;A B
Task 
< "
AdditionalEquipmentDto #
># $!
GetVehicleByEquipment% :
(: ;
Guid; ?!
additionalEquipmentId@ U
)U V
;V W
} 
} ∏$
IF:\Projects\UsedCars\UsedCars.Services\CategoryService\CategoryService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

class 
CategoryService  
:! "
ICategoryService# 3
{ 
private 
readonly 
ICategoryRepo &
_categoryRepo' 4
;4 5
private 
readonly 
IMapper  
_mapper! (
;( )
public 
CategoryService 
( 
ICategoryRepo ,
categoryRepo- 9
,9 :
IMapper; B
mapperC I
)I J
{ 	
_categoryRepo 
= 
categoryRepo (
??) +
throw, 1
new2 5!
ArgumentNullException6 K
(K L
nameofL R
(R S
categoryRepoS _
)_ `
)` a
;a b
_mapper 
= 
mapper 
?? 
throw  %
new& )!
ArgumentNullException* ?
(? @
nameof@ F
(F G
mapperG M
)M N
)N O
;O P
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
CategoryDto& 1
>1 2
>2 3
GetCategories4 A
(A B
)B C
{ 	
var 

categories 
= 
await "
_categoryRepo# 0
.0 1
GetAllAsync1 <
(< =
)= >
;> ?
var 
categoriesToReturn "
= 
_mapper 
. 
Map 
< 
IEnumerable )
<) *
CategoryDto* 5
>5 6
>6 7
(7 8

categories8 B
)B C
;C D
return 
categoriesToReturn %
;% &
} 	
public!! 
async!! 
Task!! 
<!! 
CategoryDto!! %
>!!% &
GetCategory!!' 2
(!!2 3
Guid!!3 7
modelId!!8 ?
)!!? @
{"" 	
var## 
category## 
=## 
await##  
_categoryRepo##! .
.##. /
GetById##/ 6
(##6 7
modelId##7 >
)##> ?
;##? @
var$$ 
categoryToReturn$$  
=$$! "
_mapper$$# *
.$$* +
Map$$+ .
<$$. /
CategoryDto$$/ :
>$$: ;
($$; <
category$$< D
)$$D E
;$$E F
return%% 
categoryToReturn%% #
;%%# $
}&& 	
public(( 
async(( 
Task(( 
<(( 
CategoryDto(( %
>((% &
CreateCategory((' 5
(((5 6
CategoryDto((6 A
categoryDto((B M
)((M N
{)) 	
var** 
categoryToCreate**  
=**! "
_mapper**# *
.*** +
Map**+ .
<**. /
Category**/ 7
>**7 8
(**8 9
categoryDto**9 D
)**D E
;**E F
await++ 
_categoryRepo++ 
.++  
InsertAsync++  +
(+++ ,
categoryToCreate++, <
)++< =
;++= >
await,, 
_categoryRepo,, 
.,,  
	SaveAsync,,  )
(,,) *
),,* +
;,,+ ,
var-- 
categoryToReturn--  
=--! "
_mapper--# *
.--* +
Map--+ .
<--. /
CategoryDto--/ :
>--: ;
(--; <
categoryToCreate--< L
)--L M
;--M N
return.. 
categoryToReturn.. #
;..# $
}00 	
public22 
async22 
Task22 
DeleteCategory22 (
(22( )
Guid22) -

categoryId22. 8
)228 9
{33 	
var44 
categoryToDelete44  
=44! "
await44# (
_categoryRepo44) 6
.446 7
GetById447 >
(44> ?

categoryId44? I
)44I J
;44J K
var55 
deleteCategory55 
=55  
await55! &
_categoryRepo55' 4
.554 5
Delete555 ;
(55; <
categoryToDelete55< L
)55L M
;55M N
await66 
_categoryRepo66 
.66  
	SaveAsync66  )
(66) *
)66* +
;66+ ,
}88 	
}99 
}:: ‰
JF:\Projects\UsedCars\UsedCars.Services\CategoryService\ICategoryService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

	interface 
ICategoryService %
{ 
Task 
< 
CategoryDto 
> 
CreateCategory (
(( )
CategoryDto) 4
categoryDto5 @
)@ A
;A B
Task 
DeleteCategory 
( 
Guid  

categoryId! +
)+ ,
;, -
Task		 
<		 
IEnumerable		 
<		 
CategoryDto		 $
>		$ %
>		% &
GetCategories		' 4
(		4 5
)		5 6
;		6 7
Task

 
<

 
CategoryDto

 
>

 
GetCategory

 %
(

% &
Guid

& *
modelId

+ 2
)

2 3
;

3 4
} 
} Æ
BF:\Projects\UsedCars\UsedCars.Services\MakeService\IMakeService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

	interface 
IMakeService !
{ 
Task 
< 
MakeDto 
> 

CreateMake  
(  !
MakeDto! (
makeDto) 0
)0 1
;1 2
Task 

DeleteMake 
( 
Guid 
makeId #
)# $
;$ %
Task		 
<		 
MakeDto		 
>		 
GetMake		 
(		 
Guid		 "
makeId		# )
)		) *
;		* +
Task

 
<

 
IEnumerable

 
<

 
MakeDto

  
>

  !
>

! "
GetMakes

# +
(

+ ,
)

, -
;

- .
} 
} ¬"
AF:\Projects\UsedCars\UsedCars.Services\MakeService\MakeService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

class 
MakeService 
: 
IMakeService +
{ 
private 
readonly 
	IMakeRepo "
	_makeRepo# ,
;, -
private 
readonly 
IMapper  
_mapper! (
;( )
public 
MakeService 
( 
	IMakeRepo $
makeRepo% -
,- .
IMapper/ 6
mapper7 =
)= >
{ 	
	_makeRepo 
= 
makeRepo  
??! #
throw$ )
new* -!
ArgumentNullException. C
(C D
nameofD J
(J K
makeRepoK S
)S T
)T U
;U V
_mapper 
= 
mapper 
?? 
throw  %
new& )!
ArgumentNullException* ?
(? @
nameof@ F
(F G
mapperG M
)M N
)N O
;O P
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
MakeDto& -
>- .
>. /
GetMakes0 8
(8 9
)9 :
{ 	
var 
makes 
= 
await 
	_makeRepo '
.' (
GetAllAsync( 3
(3 4
)4 5
;5 6
var 
makesToReturn 
= 
_mapper  '
.' (
Map( +
<+ ,
IEnumerable, 7
<7 8
MakeDto8 ?
>? @
>@ A
(A B
makesB G
)G H
;H I
return 
makesToReturn  
;  !
} 	
public   
async   
Task   
<   
MakeDto   !
>  ! "
GetMake  # *
(  * +
Guid  + /
makeId  0 6
)  6 7
{!! 	
var"" 
make"" 
="" 
await"" 
	_makeRepo"" &
.""& '
GetById""' .
("". /
makeId""/ 5
)""5 6
;""6 7
var## 
makesToReturn## 
=## 
_mapper##  '
.##' (
Map##( +
<##+ ,
MakeDto##, 3
>##3 4
(##4 5
make##5 9
)##9 :
;##: ;
return$$ 
makesToReturn$$  
;$$  !
}%% 	
public'' 
async'' 
Task'' 
<'' 
MakeDto'' !
>''! "

CreateMake''# -
(''- .
MakeDto''. 5
makeDto''6 =
)''= >
{(( 	
var)) 
makeToCreate)) 
=)) 
_mapper)) &
.))& '
Map))' *
<))* +
Make))+ /
>))/ 0
())0 1
makeDto))1 8
)))8 9
;))9 :
await** 
	_makeRepo** 
.** 
InsertAsync** &
(**& '
makeToCreate**' 3
)**3 4
;**4 5
await++ 
	_makeRepo++ 
.++ 
	SaveAsync++ $
(++$ %
)++% &
;++& '
var,, 
makeToReturn,, 
=,, 
_mapper,, &
.,,& '
Map,,' *
<,,* +
MakeDto,,+ 2
>,,2 3
(,,3 4
makeToCreate,,4 @
),,@ A
;,,A B
return-- 
makeToReturn-- 
;--  
}// 	
public11 
async11 
Task11 

DeleteMake11 $
(11$ %
Guid11% )
makeId11* 0
)110 1
{22 	
var33 
makeToDelete33 
=33 
	_makeRepo33 (
.33( )
GetById33) 0
(330 1
makeId331 7
)337 8
;338 9
var44 
deleteModel44 
=44 
	_makeRepo44 '
.44' (
Delete44( .
(44. /
makeToDelete44/ ;
)44; <
;44< =
await55 
	_makeRepo55 
.55 
	SaveAsync55 %
(55% &
)55& '
;55' (
}77 	
}88 
}99 ∏
DF:\Projects\UsedCars\UsedCars.Services\ModelService\IModelService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

	interface 
IModelService "
{ 
Task 
< 
MakeDto 
> 
CreateModel !
(! "
MakeDto" )
modelDto* 2
)2 3
;3 4
Task		 
DeleteModel		 
(		 
Guid		 
modelId		 %
)		% &
;		& '
Task

 
<

 
MakeDto

 
>

 
GetModel

 
(

 
Guid

 #
modelId

$ +
)

+ ,
;

, -
Task 
< 
IEnumerable 
< 
MakeDto  
>  !
>! "
	GetModels# ,
(, -
)- .
;. /
} 
} ⁄"
CF:\Projects\UsedCars\UsedCars.Services\ModelService\ModelService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

class 
ModelService 
: 
IModelService  -
{ 
private 
readonly 

IModelRepo #

_modelRepo$ .
;. /
private 
readonly 
IMapper  
_mapper! (
;( )
public 
ModelService 
( 

IModelRepo &
	modelRepo' 0
,0 1
IMapper2 9
mapper: @
)@ A
{ 	

_modelRepo 
= 
	modelRepo "
??# %
throw& +
new, /!
ArgumentNullException0 E
(E F
nameofF L
(L M
	modelRepoM V
)V W
)W X
;X Y
_mapper 
= 
mapper 
?? 
throw  %
new& )!
ArgumentNullException* ?
(? @
nameof@ F
(F G
mapperG M
)M N
)N O
;O P
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
MakeDto& -
>- .
>. /
	GetModels0 9
(9 :
): ;
{ 	
var 
models 
= 
await 

_modelRepo )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
var 
modelsToReturn 
=  
_mapper! (
.( )
Map) ,
<, -
IEnumerable- 8
<8 9
MakeDto9 @
>@ A
>A B
(B C
modelsC I
)I J
;J K
return 
modelsToReturn !
;! "
} 	
public   
async   
Task   
<   
MakeDto   !
>  ! "
GetModel  # +
(  + ,
Guid  , 0
modelId  1 8
)  8 9
{!! 	
var"" 
model"" 
="" 
await"" 

_modelRepo"" (
.""( )
GetById"") 0
(""0 1
modelId""1 8
)""8 9
;""9 :
var## 
modelToReturn## 
=## 
_mapper##  '
.##' (
Map##( +
<##+ ,
MakeDto##, 3
>##3 4
(##4 5
model##5 :
)##: ;
;##; <
return$$ 
modelToReturn$$  
;$$  !
}%% 	
public'' 
async'' 
Task'' 
<'' 
MakeDto'' !
>''! "
CreateModel''# .
(''. /
MakeDto''/ 6
modelDto''7 ?
)''? @
{(( 	
var)) 
modelToCreate)) 
=)) 
_mapper))  '
.))' (
Map))( +
<))+ ,
Model)), 1
>))1 2
())2 3
modelDto))3 ;
))); <
;))< =
await** 

_modelRepo** 
.** 
InsertAsync** (
(**( )
modelToCreate**) 6
)**6 7
;**7 8
await++ 

_modelRepo++ 
.++ 
	SaveAsync++ &
(++& '
)++' (
;++( )
var,, 
modelToReturn,, 
=,, 
_mapper,,  '
.,,' (
Map,,( +
<,,+ ,
MakeDto,,, 3
>,,3 4
(,,4 5
modelToCreate,,5 B
),,B C
;,,C D
return-- 
modelToReturn--  
;--  !
}// 	
public11 
async11 
Task11 
DeleteModel11 %
(11% &
Guid11& *
modelId11+ 2
)112 3
{22 	
var33 
modelToDelete33 
=33 
await33  %

_modelRepo33& 0
.330 1
GetById331 8
(338 9
modelId339 @
)33@ A
;33A B
await44 

_modelRepo44 
.44 
Delete44 #
(44# $
modelToDelete44$ 1
)441 2
;442 3
await55 

_modelRepo55 
.55 
	SaveAsync55 &
(55& '
)55' (
;55( )
}77 	
}88 
}99 “
IF:\Projects\UsedCars\UsedCars.Services\Vehicle.Service\IVehicleService.cs
	namespace 	
UsedCars
 
. 
Services 
{ 
public 

	interface 
IVehicleService $
{ 
Task 
< 

VehicleDto 
> 
CreateVehicleAsync +
(+ ,

VehicleDto, 6
vehicle7 >
)> ?
;? @
Task		 
DeleteVehicle		 
(		 
Guid		 
	vehicleId		  )
)		) *
;		* +
Task

 
<

 
IEnumerable

 
<

 

VehicleDto

 #
>

# $
>

$ %
GetAllVehicles

& 4
(

4 5
)

5 6
;

6 7
Task 
< 

VehicleDto 
> 

GetVehicle #
(# $
Guid$ (
	vehicleId) 2
)2 3
;3 4
Task 
< 

VehicleDto 
> 
PatchVehicle %
(% &
Guid& *
	vehicleId+ 4
,4 5
JsonPatchDocument6 G
<G H

VehicleDtoH R
>R S
patchDocumentT a
)a b
;b c
Task 
< 

VehicleDto 
> 
UpdateVehicle &
(& '

VehicleDto' 1
vehicle2 9
)9 :
;: ;
} 
} —T
HF:\Projects\UsedCars\UsedCars.Services\Vehicle.Service\VehicleService.cs
	namespace 	
UsedCars
 
. 
Services 
{		 
public

 

class

 
VehicleService

 
:

  !
IVehicleService

" 1
{ 
private 
readonly 
IVehicleRepo %
_vehicleRepo& 2
;2 3
private 
readonly 
IMapper  
_mapper! (
;( )
public 
VehicleService 
( 
IVehicleRepo *
vehicleRepo+ 6
,6 7
IMapper8 ?
mapper@ F
)F G
{ 	
_vehicleRepo 
= 
vehicleRepo &
??' )
throw* /
new0 3!
ArgumentNullException4 I
(I J
nameofJ P
(P Q
vehicleRepoQ \
)\ ]
)] ^
;^ _
_mapper 
= 
mapper 
?? 
throw  %
new& )!
ArgumentNullException* ?
(? @
nameof@ F
(F G
mapperG M
)M N
)N O
;O P
} 	
public 
async 
Task 
< 
IEnumerable %
<% &

VehicleDto& 0
>0 1
>1 2
GetAllVehicles3 A
(A B
)B C
{ 	
var 
vehiclesFromRepo  
=! "
await# (
_vehicleRepo) 5
.5 6
GetAllAsync6 A
(A B
)B C
;C D
var 
vehiclesToReturn  
=! "
_mapper# *
.* +
Map+ .
<. /
IEnumerable/ :
<: ;

VehicleDto; E
>E F
>F G
(G H
vehiclesFromRepoH X
)X Y
;Y Z
return 
vehiclesToReturn #
;# $
} 	
public 
async 
Task 
< 

VehicleDto $
>$ %

GetVehicle& 0
(0 1
Guid1 5
	vehicleId6 ?
)? @
{ 	
var 
vehicleFromRepo 
=  !
await" '
_vehicleRepo( 4
.4 5
GetById5 <
(< =
	vehicleId= F
)F G
;G H
var 
vehicleToReturn 
=  !
_mapper" )
.) *
Map* -
<- .

VehicleDto. 8
>8 9
(9 :
vehicleFromRepo: I
)I J
;J K
return 
vehicleToReturn "
;" #
}   	
public"" 
async"" 
Task"" 
<"" 

VehicleDto"" $
>""$ %
CreateVehicleAsync""& 8
(""8 9

VehicleDto""9 C
vehicle""D K
)""K L
{## 	
var$$ 
vehicleEntity$$ 
=$$ 
_mapper$$  '
.$$' (
Map$$( +
<$$+ ,
Entities$$, 4
.$$4 5
Vehicle$$5 <
>$$< =
($$= >
vehicle$$> E
)$$E F
;$$F G
await%% 
_vehicleRepo%% 
.%% 
InsertAsync%% )
(%%) *
vehicleEntity%%* 7
)%%7 8
;%%8 9
await&& 
_vehicleRepo&& 
.&& 
	SaveAsync&& '
(&&' (
)&&( )
;&&) *
var(( 
vehicleToReturn(( 
=((  !
_mapper((" )
.(() *
Map((* -
<((- .

VehicleDto((. 8
>((8 9
(((9 :
vehicleEntity((: G
)((G H
;((H I
return** 
vehicleToReturn** "
;**" #
}++ 	
public-- 
async-- 
Task-- 
<-- 

VehicleDto-- $
>--$ %
UpdateVehicle--& 3
(--3 4

VehicleDto--4 >
vehicle--? F
)--F G
{.. 	
if// 
(// 
!// 
_vehicleRepo// 
.// 
VehicleExists// +
(//+ ,
vehicle//, 3
.//3 4
Id//4 6
)//6 7
)//7 8
{00 
return11 
null11 
;11 
}22 
var44 
vehicleFromRepo44 
=44  !
await44" '
_vehicleRepo44( 4
.444 5
GetById445 <
(44< =
vehicle44= D
.44D E
Id44E G
)44G H
;44H I
if66 
(66 
vehicleFromRepo66 
==66  "
null66# '
)66' (
{77 
var88 
vehicleToAdd88  
=88! "
_mapper88# *
.88* +
Map88+ .
<88. /
Vehicle88/ 6
>886 7
(887 8
vehicle888 ?
)88? @
;88@ A
vehicleToAdd99 
.99 
Id99 
=99  !
vehicle99" )
.99) *
Id99* ,
;99, -
await;; 
_vehicleRepo;; "
.;;" #
InsertAsync;;# .
(;;. /
vehicleToAdd;;/ ;
);;; <
;;;< =
await== 
_vehicleRepo== "
.==" #
	SaveAsync==# ,
(==, -
)==- .
;==. /
var?? 
vehicleToReturn?? #
=??$ %
_mapper??& -
.??- .
Map??. 1
<??1 2

VehicleDto??2 <
>??< =
(??= >
vehicleToAdd??> J
)??J K
;??K L
returnAA 
vehicleToReturnAA &
;AA& '
}CC 
_mapperDD 
.DD 
MapDD 
(DD 
vehicleDD 
,DD  
vehicleFromRepoDD! 0
)DD0 1
;DD1 2
awaitFF 
_vehicleRepoFF 
.FF 
UpdateAsyncFF *
(FF* +
vehicleFromRepoFF+ :
)FF: ;
;FF; <
awaitHH 
_vehicleRepoHH 
.HH 
	SaveAsyncHH (
(HH( )
)HH) *
;HH* +
varJJ 
vehiclToReturnJJ 
=JJ  
_mapperJJ! (
.JJ( )
MapJJ) ,
<JJ, -

VehicleDtoJJ- 7
>JJ7 8
(JJ8 9
vehicleFromRepoJJ9 H
)JJH I
;JJI J
returnLL 
vehiclToReturnLL !
;LL! "
}NN 	
publicPP 
asyncPP 
TaskPP 
<PP 

VehicleDtoPP $
>PP$ %
PatchVehiclePP& 2
(PP2 3
GuidPP3 7
	vehicleIdPP8 A
,PPA B
JsonPatchDocumentPPC T
<PPT U

VehicleDtoPPU _
>PP_ `
patchDocumentPPa n
)PPn o
{QQ 	
ifRR 
(RR 
!RR 
_vehicleRepoRR 
.RR 
VehicleExistsRR +
(RR+ ,
	vehicleIdRR, 5
)RR5 6
)RR6 7
{SS 
returnTT 
nullTT 
;TT 
}UU 
varWW 
vehicleFromRepoWW 
=WW  !
awaitWW" '
_vehicleRepoWW( 4
.WW4 5
GetByIdWW5 <
(WW< =
	vehicleIdWW= F
)WWF G
;WWG H
ifYY 
(YY 
vehicleFromRepoYY 
==YY  "
nullYY# '
)YY' (
{ZZ 
var[[ 

vehicleDto[[ 
=[[  
new[[! $

VehicleDto[[% /
([[/ 0
)[[0 1
;[[1 2
patchDocument\\ 
.\\ 
ApplyTo\\ %
(\\% &

vehicleDto\\& 0
)\\0 1
;\\1 2
var`` 
vehicleToAdd``  
=``! "
_mapper``# *
.``* +
Map``+ .
<``. /
Vehicle``/ 6
>``6 7
(``7 8

vehicleDto``8 B
)``B C
;``C D
vehicleToAddaa 
.aa 
Idaa 
=aa  !
	vehicleIdaa" +
;aa+ ,
awaitcc 
_vehicleRepocc !
.cc! "
InsertAsynccc" -
(cc- .
vehicleToAddcc. :
)cc: ;
;cc; <
awaitee 
_vehicleRepoee "
.ee" #
	SaveAsyncee# ,
(ee, -
)ee- .
;ee. /
vargg 
vehicleToReturngg #
=gg$ %
_mappergg& -
.gg- .
Mapgg. 1
<gg1 2

VehicleDtogg2 <
>gg< =
(gg= >
vehicleToAddgg> J
)ggJ K
;ggK L
returnii 
vehicleToReturnii &
;ii& '
}jj 
varll 
vehicleToPatchll 
=ll  
_mapperll! (
.ll( )
Mapll) ,
<ll, -

VehicleDtoll- 7
>ll7 8
(ll8 9
vehicleFromRepoll9 H
)llH I
;llI J
patchDocumentnn 
.nn 
ApplyTonn !
(nn! "
vehicleToPatchnn" 0
)nn0 1
;nn1 2
_mapperrr 
.rr 
Maprr 
(rr 
vehicleToPatchrr &
,rr& '
vehicleFromReporr( 7
)rr7 8
;rr8 9
awaittt 
_vehicleRepott 
.tt 
UpdateAsynctt *
(tt* +
vehicleFromRepott+ :
)tt: ;
;tt; <
awaitvv 
_vehicleRepovv 
.vv 
	SaveAsyncvv (
(vv( )
)vv) *
;vv* +
varxx 
updatedVehiclexx 
=xx  
awaitxx! &
_vehicleRepoxx' 3
.xx3 4
GetByIdxx4 ;
(xx; <
	vehicleIdxx< E
)xxE F
;xxF G
varyy 
updatedVehicleDtoyy !
=yy" #
_mapperyy$ +
.yy+ ,
Mapyy, /
<yy/ 0

VehicleDtoyy0 :
>yy: ;
(yy; <
updatedVehicleyy< J
)yyJ K
;yyK L
return{{ 
updatedVehicleDto{{ $
;{{$ %
}|| 	
public~~ 
async~~ 
Task~~ 
DeleteVehicle~~ '
(~~' (
Guid~~( ,
	vehicleId~~- 6
)~~6 7
{ 	
var
ÄÄ 
vehicleFromRepo
ÄÄ 
=
ÄÄ  !
await
ÄÄ" '
_vehicleRepo
ÄÄ( 4
.
ÄÄ4 5
GetById
ÄÄ5 <
(
ÄÄ< =
	vehicleId
ÄÄ= F
)
ÄÄF G
;
ÄÄG H
await
ÇÇ 
_vehicleRepo
ÇÇ 
.
ÇÇ 
Delete
ÇÇ $
(
ÇÇ$ %
vehicleFromRepo
ÇÇ% 4
)
ÇÇ4 5
;
ÇÇ5 6
await
ÉÉ 
_vehicleRepo
ÉÉ 
.
ÉÉ 
	SaveAsync
ÉÉ '
(
ÉÉ' (
)
ÉÉ( )
;
ÉÉ) *
}
ÑÑ 	
}
ÖÖ 
}ÜÜ 