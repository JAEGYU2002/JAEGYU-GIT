   M S B A M L   `   `   `  ����I  EMy_Information, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:My_Information.ViewMy_Information.View  5   	   &     My_Information.View.ScheduleView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:My_Information.View     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ SCHEDULE��5
   	   $��283.5��6   $	��510��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��40 �6   �� 5      $	��170 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��170 �6   �� 5      $	��120 �6   .+�5   
   �� $��1��6   $��0��6!   $��Center=�61   $��Center=�6N   $��15(�6i   $
��Bold"�6w   ��6�   �� *
dayBlock+�� 5   
   $��1��6   $��1��6   $��
4,7,-203,7q�6/   $
��Bold"�6�   ��6C   �� *Schedule.title+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$
 test��5      $��2��6    $��1��6-   $��
4,4,-203,3q�6=   ��6Q   �� *Schedule.memo+$ PropertyChanged=�&   System.Windows.Controls.Calendar  5   
   $��2��6   $��0��6    $
��Left=�60   $��Center=�6K      SelectedDate 6f   �� *day+�� 5   
   $��3��6   $��검색��6   $
��Bold"�6+   $��13(�6=   $
��35,2q�6�   ��6K   �� *DaySelectButton+��6o   �� *
Schedule+6�   �� 5   
   $��3��6   $��1��6   $��수정��6.   $
��Bold"�6;   $��13(�6M   $��	21,2,-1,2q�6�   ��6[   �� *
EditButton+��6z   �� *
Schedule+6�   �� 5   
   $��3��6   $��1��6   $��추가��6.   $
��Bold"�6;   $��13(�6M   $��122,2,-102,2q�6�   ��6[   �� *InsertButton+��6|   �� *
Schedule+6�   �� 5   
   $��3��6   $��1��6   $��삭제��6.   $
��Bold"�6;   $��13(�6M   $��223,2,-203,2q�6�   ��6[   �� *DeleteButton+��6|   �� *
Schedule+6�   5      5       