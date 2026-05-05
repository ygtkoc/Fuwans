@extends('layouts.app')

@section('title', 'Fuwans | Modern E-Ticaret')

<div class="w-full home-page bg-[#F5F5F0]">
    @section('content')
        @include('partials.home.hero')
        @include('partials.home.second-section')
        @include('partials.home.products')
        @include('partials.home.categories')
        @include('partials.home.our-philosophy')
        @include('partials.home.subscribe')
    @endsection
</div>
