   M S B A M L   `   `   `  ����L  HSuperMargalitProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SuperMargalitProjSuperMargalitProj  5   	       SuperMargalitProj.Cyborg   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SuperMargalitProj     5   	   -   5        $
��main��5
   4     � WindowState$  	Maximized=�5   	    � WindowStyle$
 None=�5	   	    � Title$ Cyborg��5
   	   $
��1080��6   $
��1920��6'   .��5      �� -   5         ��Name$ gridi��5      .+�5   
   �� -   5        $
��3840��5      $
��1080��6    �� Left$ -3��6,    � Cursor$
 Hand��6=   ��5      �� 5       �� ImageSource$ image/tolybot/Map.jpg��6   -   5        Back��5   Q   .+�5      r� -   5        $
��Toly��5   &    r� Volume$ 1Q�6    r� Source$ Songs/TolyBot.mp3?�6P   	 r� LoadedBehavior$	 Manual=�6k   
 r� UnloadedBehavior$
 Close=�6�   $
��1080��6�   $
��1920��6�   $y�Hidden=�6�   �� 5      -   5         ��Name$ DosBox��5      $��image/tolybot/DosBox.png��6&   $	��498��6H   $ -1��6U   
 �� Top$	 581��6f   $	��510��6w   $
��Fill=�6�   �� 5      -   5        $ tolyborg��5      $ ��image/tolybot/tolyborg.png��6&   $	��257��6K   $	 368��6X   $	 324��6j   $	��147��6{   $
��Fill=�6�   �� 5      -   5        $ Arrow��5      $��68��6#   $	 567��6/   $	 374��6A   $	��102��6R   $��image/Other/Arrow.png��6^   $
��Fill=�6}    J� RenderTransformOrigin$ -1.113,-0.64&�6�   $
 Hand��6�   �� 5      -	   5        $ shoot��5      $!��image/Journey/Right/Asm.png��6#   $	��136��6I   $	 368��6V   $	 324��6h   $	��204��6y   $
��Fill=�6�   $y�Hidden=�6�   � 5      -
   5         �Name$
 Life��5      $��62��6)   $ 7��65   $ 13��6E   $	��772��6U    � Value$	 100Q�6a   �� 5      -   5        $ B1��5      $��image/tolybot/Error.png��6    $	��139��6A   $
 1943��6N   $	 910��6a   $	��154��6r   �� 5      -   5        $ B2��5      $��image/tolybot/Error.png��6    $	��139��6A   $
 1943��6N   $	 915��6a   $	��154��6r   �� 5      -   5        $ B3��5      $��image/tolybot/Error.png��6    $	��139��6A   $
 1943��6N   $	 920��6a   $	��154��6r   �� 5      -   5        $ B4��5      $��image/tolybot/Error.png��6    $	��139��6A   $
 1943��6N   $	 925��6a   $	��154��6r   �� 5      -   5        $ B5��5      $��image/tolybot/Error.png��6    $	��139��6A   $
 1943��6N   $	 930��6a   $	��154��6r   �� 5      -   5        $ U1��5      $��image/tolybot/Bug.png��6    $	��139��6?   $
 1928��6L   $ 5��6_   $	��154��6n   �� 5      -   5        $ U2��5      $��image/tolybot/Bug.png��6    $	��139��6@   $
 1928��6M   $ 10��6`   $	��154��6p   �� 5       -   5        $ U3��5       $��image/tolybot/Bug.png��6    $	��139��6@   $
 1928��6M   $ 15��6`   $	��154��6p   �� 5!      -   5        $ U4��5!      $��image/tolybot/Bug.png��6    $	��139��6@   $
 1928��6M   $ 20��6`   $	��154��6p   �� 5"      -   5        $ U5��5"      $��image/tolybot/Bug.png��6    $	��139��6@   $
 1928��6M   $ 25��6`   $	��154��6p   �� 5#      -   5         ��Name$
 lblR��5#      $��Start��6"   $	��297��62   $	 674��6?   $	 318��6Q   $
��1150��6b   $	��200(�6o   5'      5(      5)      