   M S B A M L   `   `   `  ���� Q  MDnDCharacterBuilderGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DnDCharacterBuilderGUIDnDCharacterBuilderGUI  *    $DnDCharacterBuilderGUI.StatGenerator   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:DnDCharacterBuilderGUI       � Title$  StatGenerator��$	��450��$	��600������  �� ImageSource$ background.jpg��.��� .+��� -    ��Name$ Title��$��Center=�$��0,25,0,0q�$��Ability Score Generator��$��30(�$
��Bold"�
���  ��$��	Underline{�$
��Wrap=�$	��Top=��� -   $ 
RolledList��$
��Left=�$��
150,70,0,0q�$��Rolled Scores��$��15(�$
��Bold"�
���   �$
��Wrap=�$	��Top=��� -   $ AverageList��$
��Left=�$��
350,70,0,0q�$��Average Scores��$��15(�$
��Bold"�
���   �$
��Wrap=�$	��Top=��� -    ��Name$ RolledStatsListBox��$
��Left=�$	��Top=�$��
170,90,0,0q�
�������$	��125��$��40��$��Center=��� -   $ AverageStatsListBox��$
��Left=�$	��Top=�$��
380,90,0,0q�
�������$	��125��$��40��$��Center=�.@��� $��15���� $��14���� $��13���� $��12���� $��10���� $��8���� -   $��Roll Ability Scores��$��Center=�$��	0,130,0,0q�$	��Top=��� -   $��Switch to Average Scores��$��Center=�$��	0,182,0,0q�$	��Top=��� $
��Left=�$��
64,234,0,0q�$��
Strength: ��$
��Wrap=�$	��Top=��� -    ��Name$ StrengthScoreListBox��$
��Left=�$��115,232,0,0q�$	��Top=�$��40��$��Center=��� $
��Left=�$��
64,277,0,0q�$��Dexterity: ��$
��Wrap=�$	��Top=��� -	   $ DexterityScoreListBox��$
��Left=�$��115,276,0,0q�$	��Top=�$��40��$��Center=��� $
��Left=�$��190,234,0,0q�$��Constitution: ��$
��Wrap=�$	��Top=��� -
   $ ConstitutionScoreListBox��$
��Left=�$��260,231,0,0q�$	��Top=�$��40��$��Center=��� $
��Left=�$��190,277,0,0q�$��Intelligence: ��$
��Wrap=�$	��Top=��� -   $ IntelligenceScoreListBox��$
��Left=�$��260,276,0,0q�$	��Top=�$��40��$��Center=��� $
��Left=�$��320,234,0,0q�$��Wisdom: ��$
��Wrap=�$	��Top=��� -   $ WisdomScoreListBox��$
��Left=�$��375,231,0,0q�$	��Top=�$��40��$��Center=��� $
��Left=�$��320,276,0,0q�$��
Charisma: ��$
��Wrap=�$	��Top=��� -   $ CharismaScoreListBox��$
��Left=�$��375,276,0,0q�$	��Top=�$��40��$��Center=��� -   $��Confirm Ability Scores��$
��Left=�$��420,254,0,0q�$��14(�$
��Bold"�
������
��� � �$	��Top=��� -   $��Discard Ability Scores��$
��Left=�$��420,285,0,0q�$��14(�$
��Bold"�
���  ��
�������$	��Top=�