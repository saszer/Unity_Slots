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
