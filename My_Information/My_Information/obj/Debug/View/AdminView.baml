   M S B A M L   `   `   `  ����I  EMy_Information, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:My_Information.ViewMy_Information.View  5   	   #    My_Information.View.AdminView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:My_Information.View     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ ADMIN��5
   	   $	��500��6   $	��500��6$   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   .+�5    
   �� $��0��6   $��1��6!   $��관리자 메뉴��61   $
��Bold"�6?   $��30(�6Q   $��Center=�6_   $��Center=�6z   $��3��6�   $��	70,7,70,4q�6�   $	��160��6�   �� 5"   
   $��1��6   $��1��6   $��10q�6.   $��유저 목록��6:   $
��Bold"�6J   ��6\   Z� ��6s   �� *
userButton+�� 5#   
   $��1��6   $��3��6   $��10q�6.   $��로그인 기록��6:   $
��Bold"�6K   ��6]   Z� ��6t   �� *loginLogButton+�� 5$   
   $��2��6   $��1��6   $��10q�6.   $�� ��6:   $
��Bold"�6E   ��6W   Z� ��6n   �� *t2+�� 5%   
   $��2��6   $��3��6   $��10q�6.   $��DB 초기화��6:   $
��Bold"�6K   ��6]   Z� ��6t   �� *dbResetButton+5&      5'      