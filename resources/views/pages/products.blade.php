@extends('layouts.app')

@section('title', 'Fuwans | Urunler')

@section('content')
    <div class="w-full products-page bg-[#F5F5F0]">
        @section('content')
            @include('partials.products.top')
            @include('partials.products.main')
        @endsection
    </div>
@endsection
