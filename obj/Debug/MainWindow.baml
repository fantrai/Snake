   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Snake     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $	��900��6)   .��5
      � -   5         �Name$ GamePool��5
       � ShowGridLines . 
���   � � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      .+�5+   
   �� -   5         ��Name$ 	HeadSnake��5+      
��� � �$��5��67   $��8��6D   �� 5,   
   -   5        $ AppleBox��5,      
���  ��$��4��64   $��2��6A   �� 5-   
   -   5         ��Name$ TextPan��5-      $
��Left=�6%   $
��Wrap=�6@   $��	TextBlock��6T   $	��Top=�6e   $��16��6}   $	��800��6�   $��48��6�   $��24(�6�   ���	#FF23E06C J� RenderTransformOrigin$ 	0.5,0.514&�6�   $��0,-2,0,0q�6�   �� 5.   
   -   5         ��Name$ GameOverPan��5.      $��2��6&   $��2��66   
�������$��14��6V   $��6��6k   	 K� ZIndex$	 1��6|   $y�Hidden=�6�   .+�5/      �� $P��JНажмите пробел, чтобы попробовать снова!��6   

 �� Top$
 95��6H   $	��100��6X   $	��700��6e   $��36(�6q   $
��Bold"�6   $��Comic Sans MS)�6�   $
��Wrap=�6�   $��Center=�6�    �� TextAlignment$ Center=�6�   $��Center=�6�   $��	Underline{�6  50      52      53      