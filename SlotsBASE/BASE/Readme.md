sz____sz

Slot System; 

Refer Prefabs for better understanding.

Add Slot.cs on Slots [Check Bool is EquipSlot if its a final slot(right slot to be placed after)]
Add ItemUnder The Slot and DragHandler.cs on this Item. 
With bith these scipts ItemHandler_sz will be automatically added. 

Tag both EquipSlot(Final Slot the Item needs to be placed in) and Item with the same TAG. 

On ItemHandler.cs On the Item there are several events which can be called.
- On Placed on Right Slot / Wrong Slot
- On Dragging, On Hover, On Release .. etc.. 
((Can be used to enable disable gameobjects, call scripts etc.. ))


Fits to Slot Size(localtransform reset to oneoneone)

Enable Bool 'is3DGame' On Item Manager(All Slots/Items) - Drop 3D Objects According to Icon.
Place/Link 3D object in DragHandler.cs on the Icon/Draggable Item. 
Place/Link Transform of the specific Slot in Slot.cs on slots. (PS, Only Enabled for Equip Slots)

sz.sahaj@embracingearth.space //sz.sahaj@gmail.com