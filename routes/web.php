<?php

use Illuminate\Support\Facades\Route;

Route::view('/', 'pages.home')->name('home');
Route::view('/urunler', 'pages.products')->name('products');
Route::view('/urun-detay', 'pages.product-detail')->name('product-detail');
