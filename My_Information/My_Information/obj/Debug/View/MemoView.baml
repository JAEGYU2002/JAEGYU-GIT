   M S B A M L   `   `   `  ����I  EMy_Information, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:My_Information.ViewMy_Information.View  5   	   "    My_Information.View.MemoView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:My_Information.View     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$
 MEMO��5	   	   $	��700��6   $	��700��6#   .��5
      � .+�5   
   o� $��	0,0,0,633q�6   .@�5      m� $
��Menu��6   $
��Bold"�6%   .@�5      m�  m� Icon$
 📖��6   $
��save��6%    m� Command 63   �� *
SaveButton+m� 5      $
 📝��6   $��save to txt��6%    6:   �� *SaveTextMenu+�� 5      m� 5      $	 ❕��6   $��manual��6$    64   �� *
ManualMenu+�� 5      m� 5      -   5        $	 ✕��5      $
��exit��6$   62   5      5      �� 5   
   -   5         ��Name$ MemoBox��5      $��17(�6K   $��	0,22,0,25q�6Y   ��. $��Visible=�5      $��Visible=�5      ��5   #   �� *MemoParameter.memoText+.��5   E   5      �� 5   
   $��	0,633,0,0q�6   $��저장��6$   $
��Bold"�61   $��17(�6C   ��6Q   �� *
SaveButton+��6p   �� *MemoParameter+5      5      