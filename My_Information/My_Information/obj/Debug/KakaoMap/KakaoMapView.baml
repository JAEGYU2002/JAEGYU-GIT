   M S B A M L   `   `   `  ����I  EMy_Information, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:My_Information.KakaoMapMy_Information.KakaoMap  5   	   *    $My_Information.KakaoMap.KakaoMapView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:My_Information.KakaoMap     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$	 MAP��5
   	   $	��700��6   $
��1200��6"   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��0 �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��0 �6   .+�5   
   �� -   5        $��image��5      $��mercedes-benz-logo.png��6   $��
21,0,22,17q�6=   �� 5   
   -   5        $��
tbox_query��5      
�������$��1��67   $��10,22,-271,35q�6G   �� 5   
   -   5        $��
btn_search��5       �� 	IsDefault . $��Center=�6I   $��1��6d   $��검색��6t   $
��Bold"�6�   $��24��6�   $��272,22,-301,35q�6�   ��6�   Z� 6�   �� 5   
   -   5        $��lbox_locale��5      
�������$��1��6d   $��
1,1,0,-306q�6q   �� 5   
   -   5        $��lbox_button��5      $��추가��6$   $
��Bold"�61   $��1��6C   $��1,307,109,-336q�6g   ��6P   Z� 6   �� 5   
   -   5        $��lbox_button2��5      $��삭제��6%   $
��Bold"�62   $��1��6D   $��110,307,0,-336q�6h   ��6Q   Z� 6�   �� 5   
   -   5         ��Name$ place_nameList��5      $��1��6+   $��0��68   $��1��6H   $��0,337,0,-589q�6\    �� View 5      �� 5      .P�5       �� -   5        FavoritePlaceID�� �� Width$	 195��5    >   	 �� DisplayMemberBinding	 6J   �� *
place_name+5!      5#      (  "System.Windows.Controls.WebBrowser  5%   
   -	   5        $��wb��5%      
   Source$)
 #http://127.0.0.1:8887/kakaomap.html?�6   $��1��6L   $��0,68,-1031,-602q�6\   $��2��6u   5&      5>      