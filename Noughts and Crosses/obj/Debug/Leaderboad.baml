   M S B A M L   `   `   `  ����N  JNaughts and Crosses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Naughts_and_CrossesNaughts_and_Crosses  5   	   $    Naughts_and_Crosses.Leaderboad   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Naughts_and_Crosses     5   	     � Title$  
Leaderboad��5   	   $	��450��6   $	��800��6)    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6K    � WindowStartupLocation$ CenterScreen=�6a    � AllowsTransparency .  � WindowStyle$
 None=�6�    � 	Resources 5	         FocusVisual �� Property �� Value	 J� SnapsToDevicePixels
 �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%2  &	        &	 �     &	 �     &	 �     &	     &	 0    &	 Q    &	 r    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   	 . #��� ��6J   $��1��6�   $	
 1 2R�6�   5      5      5      �� 5   
   $ #080808��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ #212121��6>   �� 5   
   $ #161715��6:   �� 5   
   $ #212121��6<   �� 5   
   $ #161715��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� $ border��6!   #��z��61   #��z��6]   #��z��6�   	 . ._�5)      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. #	 z	 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted . . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver . . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � �� . . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {� .  . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      5A      .��5B      � -   5         �Name$
 grid��5B      .+�5C   
   �� -   5         ��Name$ lblNames��5C      $��Name:��6"   $
��Left=�62   $��	69,55,0,0q�6M   $	��Top=�6`   $	��214��6x   $	��197��6�   ���	#E5080808���	#FFC8C8C8���	#FF707070$
��Bold"�6�   $��14(�6�   �� 5D   
   -   5        $ lblWins��5D      $
��Left=�6!   $��
271,55,0,0q�6<   $	��Top=�6P   $	��214��6h   $	��197��6u   ���	#E5080808���	#FFC8C8C8���	#FF707070$
��Bold"�6�   $��14(�6�   $��Wins:��6�   �� 5E   
   -   5        $ 	lblLosses��5E      $��Losses:��6#   $
��Left=�65   $��
473,55,0,0q�6P   $	��Top=�6d   $	��214��6|   $	��197��6�   ���	#E5080808���	#FFC8C8C8���	#FF707070$
��Bold"�6�   $��14(�6�   �� 5F   
   -   5         ��Name$ btnExit��5F      $	��×
��6"   $��751,0,0,422q�63   $��Bottom=�6H   $��28��6c   $��20(�6o   $
��Bold"�6}   ���	#FF080808���	#FF707070
�������#��� 
 6�   �� 5G   
   $*��$Rank:
1:
2:
3:
4:
5:
6:
7:
8:
9:
10:��6   $��10,55,731,181q�6g   ���	#E5080808���	#FFC8C8C8$
��Bold"�6�   $��14(�6�   5I      5J      