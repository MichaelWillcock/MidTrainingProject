   M S B A M L   `   `   `  ����Q  MDnDCharacterBuilderGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DnDCharacterBuilderGUIDnDCharacterBuilderGUI  5   	   *    $DnDCharacterBuilderGUI.ViewCharacter   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DnDCharacterBuilderGUI     5   	     � Title$  ViewCharacter��5   	   $	��600��6   $	��800��6,   ��5	      �� 5
   
    �� ImageSource$ background.jpg��6   .��5      � .+�5   
   �� -   5        $
��EXIT��5      $
��Left=�6    $��
70,480,0,0q�6;   $��20(�6O   
���  ��
���  ��$
��Bold"�6�   $	��Top=�6�   6�   �� 5   
   $
��Left=�6   $��175,167,0,0q�6/   $��
Strength: ��6D   $��20(�6V   $
��Wrap=�6d   $	��Top=�6x   �� 5   
   $
��Left=�6   $��175,197,0,0q�6/   $��Dexterity: ��6D   $��20(�6W   $
��Wrap=�6e   $	��Top=�6y   �� 5   
   $
��Left=�6   $��175,227,0,0q�6/   $��Constitution: ��6D   $��20(�6Z   $
��Wrap=�6h   $	��Top=�6|   �� 5   
   $
��Left=�6   $��175,257,0,0q�6/   $��Intelligence: ��6D   $��20(�6Z   $
��Wrap=�6h   $	��Top=�6|   �� 5   
   $
��Left=�6   $��175,287,0,0q�6/   $��Wisdom: ��6D   $��20(�6T   $
��Wrap=�6b   $	��Top=�6v   �� 5   
   $
��Left=�6   $��175,317,0,0q�6/   $��
Charisma: ��6D   $��20(�6V   $
��Wrap=�6d   $	��Top=�6x   �� 5   
   -   5         ��Name$ StrengthScore��5      $
��Left=�6+   $��260,164,0,0q�6F   $��25(�6[   $	��Top=�6i   $��30��6�   $��30��6�   �� 5   
   -   5        $ DexScore��5      $
��Left=�6&   $��270,194,0,0q�6A   $��25(�6V   $	��Top=�6d   $��30��6|   $��30��6�   �� 5   
   -   5        $ ConScore��5      $
��Left=�6&   $��300,224,0,0q�6A   $��25(�6V   $	��Top=�6d   $��30��6|   $��30��6�   �� 5   
   -   5        $ IntScore��5      $
��Left=�6&   $��290,254,0,0q�6A   $��25(�6V   $	��Top=�6d   $��30��6|   $��30��6�   �� 5   
   -   5        $ WisScore��5      $
��Left=�6&   $��260,284,0,0q�6A   $��25(�6V   $	��Top=�6d   $��30��6|   $��30��6�   �� 5   
   -   5        $ ChaScore��5      $
��Left=�6&   $��265,314,0,0q�6A   $��25(�6V   $	��Top=�6d   $��30��6|   $��30��6�   �� 5   
   -   5        $ StrengthMod��5      $
��Left=�6)   $��345,164,0,0q�6D   $��25(�6Y   $	��Top=�6g   $��30��6   $��30��6�   �� 5   
   -	   5        $ DexMod��5      $
��Left=�6$   $��345,194,0,0q�6?   $��25(�6T   $	��Top=�6b   $��30��6z   $��30��6�   �� 5   
   -
   5        $ ConMod��5      $
��Left=�6$   $��345,224,0,0q�6?   $��25(�6T   $	��Top=�6b   $��30��6z   $��30��6�   �� 5   
   -   5        $ IntMod��5      $
��Left=�6$   $��345,254,0,0q�6?   $��25(�6T   $	��Top=�6b   $��30��6z   $��30��6�   �� 5   
   -   5        $ WisMod��5      $
��Left=�6$   $��345,284,0,0q�6?   $��25(�6T   $	��Top=�6b   $��30��6z   $��30��6�   �� 5   
   -   5        $ ChaMod��5      $
��Left=�6$   $��345,314,0,0q�6?   $��25(�6T   $	��Top=�6b   $��30��6z   $��30��6�   �� 5    
   $
��Left=�6   $��255,135,0,0q�6/   $��Score��6D   $��20(�6Q   $
��Wrap=�6_   $	��Top=�6s   �� 5!   
   $
��Left=�6   $��340,135,0,0q�6/   $	��Mod��6D   $��20(�6O   $
��Wrap=�6]   $	��Top=�6q   �� 5"   
   $
��Left=�6   $��
215,29,0,0q�6/   $��Name: ��6C   $��20(�6Q   $
��Wrap=�6_   $	��Top=�6s   �� 5#   
   $
��Left=�6   $��
215,57,0,0q�6/   $��Race: ��6C   $��20(�6Q   $
��Wrap=�6_   $	��Top=�6s   �� 5$   
   $
��Left=�6   $��
215,85,0,0q�6/   $��Class: ��6C   $��20(�6R   $
��Wrap=�6`   $	��Top=�6t   �� 5%   
   -   5        $ NameBox��5%      $
��Left=�6%   $��
290,29,0,0q�6@   $��20(�6T   $
��Wrap=�6b   $	��Top=�6v   �� 5&   
   -   5        $ RaceBox��5&      $
��Left=�6%   $��
290,57,0,0q�6@   $��20(�6T   $
��Wrap=�6b   $	��Top=�6v   �� 5'   
   -   5        $ ClassBox��5'      $
��Left=�6&   $��
290,85,0,0q�6A   $��20(�6U   $
��Wrap=�6c   $	��Top=�6w   �� 5(   
   $
��Left=�6   $��
450,29,0,0q�6/   $��Level: ��6C   $��20(�6R   $
��Wrap=�6`   $	��Top=�6t   �� 5)   
   -   5         ��Name$ LevelBox��5)      $
��Left=�6$   $��
510,33,0,0q�6?   $��20��6S   $��15(�6]    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $��25��6�   �� 5*   
   -   5        $��	Set Level��5*      $
��Left=�6%   $��
465,64,0,0q�6@   $	��Top=�6T   6l   �� 5+   
   $
��Left=�6   $��
420,94,0,0q�6/   $��Hit Points: ��6C   $��20(�6W   $
��Wrap=�6e   $	��Top=�6y   �� 5,   
   -   5        $ HitPointBox��5,      $
��Left=�6'   $��510,100,0,0q�6B   $��15(�6W   $
 Wrap=�6e   $	��Top=�6y   $��35��6�   �� 5-   
   -   5         ��Name$ AbilitiesList��5-      $	��250��6)   $	��150��65   $
��Left=�6B   $	��Top=�6]   $��440,275,0,0q�6u   5.      5/      