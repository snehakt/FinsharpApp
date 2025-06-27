import { ChangeEvent, SyntheticEvent, useState } from "react";
import "./App.css";
import CardList from "./components/CardLists/CardList";
import Search from "./components/Search/Search";
import { CompanySearch } from "./company";
import { SearchCompanies } from "./api";
import ListPortfolio from "./components/Portfolio/ListPortfolio/ListPortfolio";
import Navbar from "./components/Navbar/Navbar";
import Hero from "./components/Hero/Hero";
import { Outlet } from "react-router";

function App() {
 
  return (
    <>
    <Navbar/>
    <Outlet/>
    </>
  );
}

export default App;
