   M S B A M L   `   `   `  ���� Q  MDnDCharacterBuilderGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DnDCharacterBuilderGUIDnDCharacterBuilderGUI  *    $DnDCharacterBuilderGUI.ViewCharacter   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:DnDCharacterBuilderGUI       � Title$  ViewCharacter��$	��600��$	��800������  �� ImageSource$ background.jpg��.��� .+��� -   $
��EXIT��$
��Left=�$��
70,480,0,0q�$��20(�
���  ��
���  ��$
��Bold"�$	��Top=��� $
��Left=�$��175,167,0,0q�$��
Strength: ��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��175,197,0,0q�$��Dexterity: ��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��175,227,0,0q�$��Constitution: ��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��175,257,0,0q�$��Intelligence: ��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��175,287,0,0q�$��Wisdom: ��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��175,317,0,0q�$��
Charisma: ��$��20(�$
��Wrap=�$	��Top=��� -    ��Name$ StrengthScore��$
��Left=�$��260,164,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ DexScore��$
��Left=�$��270,194,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ ConScore��$
��Left=�$��300,224,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ IntScore��$
��Left=�$��290,254,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ WisScore��$
��Left=�$��260,284,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ ChaScore��$
��Left=�$��265,314,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ StrengthMod��$
��Left=�$��345,164,0,0q�$��25(�$	��Top=�$��30��$��30���� -	   $ DexMod��$
��Left=�$��345,194,0,0q�$��25(�$	��Top=�$��30��$��30���� -
   $ ConMod��$
��Left=�$��345,224,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ IntMod��$
��Left=�$��345,254,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ WisMod��$
��Left=�$��345,284,0,0q�$��25(�$	��Top=�$��30��$��30���� -   $ ChaMod��$
��Left=�$��345,314,0,0q�$��25(�$	��Top=�$��30��$��30���� $
��Left=�$��255,135,0,0q�$��Score��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��340,135,0,0q�$	��Mod��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��
215,29,0,0q�$��Name: ��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��
215,57,0,0q�$��Race: ��$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��
215,85,0,0q�$��Class: ��$��20(�$
��Wrap=�$	��Top=��� -   $ NameBox��$
��Left=�$��
290,29,0,0q�$��20(�$
��Wrap=�$	��Top=��� -   $ RaceBox��$
��Left=�$��
290,57,0,0q�$��20(�$
��Wrap=�$	��Top=��� -   $ ClassBox��$
��Left=�$��
290,85,0,0q�$��20(�$
��Wrap=�$	��Top=��� $
��Left=�$��
450,29,0,0q�$��Level: ��$��20(�$
��Wrap=�$	��Top=��� -    ��Name$ LevelBox��$
��Left=�$��
510,33,0,0q�$��20��$��15(� �� TextWrapping$
 Wrap=�$	��Top=�$��25���� -   $��	Set Level��$
��Left=�$��
465,64,0,0q�$	��Top=��� $
��Left=�$��
420,94,0,0q�$��Hit Points: ��$��20(�$
��Wrap=�$	��Top=��� -   $ HitPointBox��$
��Left=�$��510,100,0,0q�$��15(�$
 Wrap=�$	��Top=�$��35���� -    ��Name$ AbilitiesList��$	��250��$	��150��$
��Left=�$	��Top=�$��440,275,0,0q�