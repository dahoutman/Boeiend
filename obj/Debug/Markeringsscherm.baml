   M S B A M L   `   `   `  ����F  BBoeiend, Version=0.6.1.20316, Culture=neutral, PublicKeyToken=null!clr-namespace:BoeiendBoeiend  5          Boeiend.Markeringsscherm   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      'localclr-namespace:Boeiend     5      .��5      �   � RowDefinitions  5      �� 5      $��4* �6   �� 5	      $
��Auto �6   �� 5
      $��1* �6   .+�5      � $��0��5        5      �� 5      �� 5      $
��Auto �5      .+�5      �� -   5        $��lvMarkeringen��5      $��0��5       �� View 5      �� 5       �� AllowsColumnReorder .  .P�5      �� $��	Vaarwater��6    �� DisplayMemberBinding 6*   �� *	Vaarwater+�� 5      $
��Code��6    6%   �� *	Benam_cod+�� 5      $��Benaming��6    6)   �� *
Benaming+�� 5      $��S57 ID��6    6'   �� *S57_id+�� 5      $��	Inbedrijf��6    6*   �� *	Inbedrijf+�� 5      $
��X rd��6    6%   �� *Y_rd+�� 5      $
��Y rd��6    6%   �� *X_rd+�� 5       $��Soort��6    6&   �� *	Obj_soort+�� 5!      $�� ��6    6!   �� *
Iala_cat+�� 5"      $��N wgs��6    6&   �� *	N_wgs_gms+�� 5#      $��E wgs��6    6&   �� *	E_wgs_gms+�� 5$      $��N wgs��6    6&   �� *
N_wgs_gm+�� 5%      $��E wgs��6    6&   �� *
E_wgs_gm+�� 5&      $��Vormcode��6    6)   �� *
Obj_vorm_c+�� 5'      $
��Vorm��6    6%   �� *
Obj_vorm+�� 5(      $��	Kleurcode��6    6*   �� *Obj_kleur_c+�� 5)      $��Kleur��6    6&   �� *	Obj_kleur+�� 5*      $��Patrooncode��6    6,   �� *Kleurpatr_c+�� 5+      $��Kleurpatroon��6    6-   �� *	Kleurpatr+�� 5,      $��V_tt_c��6    6'   �� *V_tt_c+�� 5-      $��	Tt_toptek��6    6*   �� *	Tt_toptek+�� 5.      $��
Tt_kleur_c��6    6+   �� *
Tt_kleur_c+�� 5/      $��Tt_kleur��6    6)   �� *
Tt_kleur+�� 50      $��Tt_pat_c��6    6)   �� *
Tt_pat_c+�� 51      $��
Tt_klr_pat��6    6+   �� *
Tt_klr_pat+�� 52      $��Signaalcode��6    6,   �� *
Sign_kar_c+�� 53      $��Karakteristiek��6    6/   �� *
Sign_kar+�� 54      $��
Groepscode��6    6+   �� *	Sign_gr_c+�� 55      $��Groep��6    6&   �� *
Sign_groep+�� 56      $��Periode��6    6(   �� *
Sign_perio+�� 57      $��Racon��6    6&   �� *
Racon_code+�� 58      $��	Lichtcode��6    6*   �� *
Licht_kl_c+�� 59      $��
Lichtkleur��6    6+   �� *	Licht_klr+�� 5:      $��	Opgeheven��6    6*   �� *	Opgeheven+�� 5;      $��X wgs84��6    6(   �� *	X_wgs84+�� 5<      $��Y wgs84��6    6(   �� *	Y_wgs84+5=      5?      5@      �� 5A      
������� �� ResizeDirection$
 Rows=�5C      $��1��5D      $��5��5E       �� ResizeBehavior$ PreviousAndNext=�5F      $��Center=�5G      $��Stretch=�5H      �� 5I   
   -   5        $��lbVaarwater��5J      $��2��5I      ��5K      �� 5L      .R�5M      �� -   5         d� 	IsChecked 5M   Q   �� *Value+��6m   �� *Key+5N      5P      5Q      5R      