Ó
EF:\Projects\UsedCars\UsedCars.Models\Models\AdditionalEquipmentDto.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class "
AdditionalEquipmentDto '
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ½
:F:\Projects\UsedCars\UsedCars.Models\Models\CategoryDto.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class 
CategoryDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
}		 µ
6F:\Projects\UsedCars\UsedCars.Models\Models\MakeDto.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class 
MakeDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ·
7F:\Projects\UsedCars\UsedCars.Models\Models\ModelDto.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class 
ModelDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
} Å
HF:\Projects\UsedCars\UsedCars.Models\Models\UpdateAdditionalEquipment.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class %
UpdateAdditionalEquipment *
{ 
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
} µ
@F:\Projects\UsedCars\UsedCars.Models\Models\UpdateCategoryDto.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class 
UpdateCategoryDto "
{ 
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ­
<F:\Projects\UsedCars\UsedCars.Models\Models\UpdateMakeDto.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class 
UpdateMakeDto 
{ 
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
} 
} ó	
9F:\Projects\UsedCars\UsedCars.Models\Models\VehicleDto.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class 

VehicleDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
Name 
{ 
get !
;! "
set# &
;& '
}( )
public		 
Guid		 

CategoryId		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public 
Guid 
ModelId 
{ 
get !
;! "
set# &
;& '
}( )
public 
Guid 
MakeId 
{ 
get  
;  !
set" %
;% &
}' (
List 
< "
AdditionalEquipmentDto #
># $
?$ %&
AdditionalEquipmentDtoList& @
{A B
getC F
;F G
setH K
;K L
}M N
} 
} Ô
BF:\Projects\UsedCars\UsedCars.Models\Models\VehicleEquipmentDto.cs
	namespace 	
UsedCars
 
. 
Models 
{ 
public 

class 
VehicleEquipmentDto $
{ 
public 
Guid 
	VehicleId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
Guid		 !
AdditionalEquipmentId		 )
{		* +
get		, /
;		/ 0
set		1 4
;		4 5
}		6 7
} 
} 