   M S B A M L   `   `   `  ����Q  MDnDCharacterBuilderGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DnDCharacterBuilderGUIDnDCharacterBuilderGUI  5   	   *    $DnDCharacterBuilderGUI.StatGenerator   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DnDCharacterBuilderGUI     5   	     � Title$  StatGenerator��5   	   $	��450��6   $	��600��6,   ��5	      �� 5
   
    �� ImageSource$ background.jpg��6   .��5      � .+�5   
   �� -   5         ��Name$ Title��5      $��Center=�6#   $��0,25,0,0q�6@   $��Ability Score Generator��6R   $��30(�6q   $
��Bold"�6   
���  ��$��	Underline{�6�   $
��Wrap=�6�   $	��Top=�6�   �� 5   
   -   5        $ 
RolledList��5      $
��Left=�6(   $��
150,70,0,0q�6C   $��Rolled Scores��6W   $��15(�6l   $
��Bold"�6z   
���   �$
��Wrap=�6�   $	��Top=�6�   �� 5   
   -   5        $ AverageList��5      $
��Left=�6)   $��
350,70,0,0q�6D   $��Average Scores��6X   $��15(�6n   $
��Bold"�6|   
���   �$
��Wrap=�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ RolledStatsListBox��5      $
��Left=�6.   $	��Top=�6I   $��
170,90,0,0q�6a   
�������$	��125��6�   $��40��6�   $��Center=�6�   �� 5   
   -   5        $ AverageStatsListBox��5      $
��Left=�6/   $	��Top=�6J   $��
380,90,0,0q�6b   
�������$	��125��6�   $��40��6�   $��Center=�6�   .@�5      �� $��15��6   �� 5      $��14��6   �� 5      $��13��6   �� 5      $��12��6   �� 5      $��10��6   �� 5      $��8��6   5      �� 5   
   -   5        $��Roll Ability Scores��5      $��Center=�6/   $��	0,130,0,0q�6L   $	��Top=�6_   6w   �� 5   
   -   5        $��Switch to Average Scores��5      $��Center=�64   $��	0,182,0,0q�6Q   $	��Top=�6d   6|   �� 5   
   $
��Left=�6   $��
64,234,0,0q�6/   $��
Strength: ��6C   $
��Wrap=�6U   $	��Top=�6i   �� 5   
   -   5         ��Name$ StrengthScoreListBox��5      $
��Left=�61   $��115,232,0,0q�6L   $	��Top=�6a   $��40��6y   $��Center=�6�   �� 5   
   $
��Left=�6   $��
64,277,0,0q�6/   $��Dexterity: ��6C   $
��Wrap=�6V   $	��Top=�6j   �� 5   
   -	   5        $ DexterityScoreListBox��5      $
��Left=�62   $��115,276,0,0q�6M   $	��Top=�6b   $��40��6z   $��Center=�6�   �� 5   
   $
��Left=�6   $��190,234,0,0q�6/   $��Constitution: ��6D   $
��Wrap=�6Z   $	��Top=�6n   �� 5    
   -
   5        $ ConstitutionScoreListBox��5       $
��Left=�65   $��260,231,0,0q�6P   $	��Top=�6e   $��40��6}   $��Center=�6�   �� 5!   
   $
��Left=�6   $��190,277,0,0q�6/   $��Intelligence: ��6D   $
��Wrap=�6Z   $	��Top=�6n   �� 5"   
   -   5        $ IntelligenceScoreListBox��5"      $
��Left=�65   $��260,276,0,0q�6P   $	��Top=�6e   $��40��6}   $��Center=�6�   �� 5#   
   $
��Left=�6   $��320,234,0,0q�6/   $��Wisdom: ��6D   $
��Wrap=�6T   $	��Top=�6h   �� 5$   
   -   5        $ WisdomScoreListBox��5$      $
��Left=�6/   $��375,231,0,0q�6J   $	��Top=�6_   $��40��6w   $��Center=�6�   �� 5%   
   $
��Left=�6   $��320,276,0,0q�6/   $��
Charisma: ��6D   $
��Wrap=�6V   $	��Top=�6j   �� 5&   
   -   5        $ CharismaScoreListBox��5&      $
��Left=�61   $��375,276,0,0q�6L   $	��Top=�6a   $��40��6y   $��Center=�6�   �� 5'   
   -   5        $��Confirm Ability Scores��5'      $
��Left=�62   $��420,254,0,0q�6M   $��14(�6b   $
��Bold"�6p   
������
��� � �$	��Top=�6�   6�   �� 5(   
   -   5        $��Discard Ability Scores��5(      $
��Left=�62   $��420,285,0,0q�6M   $��14(�6b   $
��Bold"�6p   
���  ��
�������$	��Top=�6�   6�   5)      5*      