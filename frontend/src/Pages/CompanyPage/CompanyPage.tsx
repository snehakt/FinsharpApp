import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import { CompanyProfile } from "../../company";
import { getCompanyProfile } from "../../api";
import Sidebar from "../../components/Sidebar/Sidebar";
import CompanyDashboard from "../../components/CompanyDashboard/CompanyDashboard";
import Tile from "../../components/Tile/Tile";
import Spinners from "../../components/Spinners/Spinners";
import CompFinder from "../../components/CompFinder/CompFinder";
import TenKFinder from "../../components/TenKFinder/TenKFinder";

type Props = {};

export const CompanyPage = (props: Props) => {
  let { ticker } = useParams();
  const [company, setCompany] = useState<CompanyProfile>();

  useEffect(() => {
    const getProfileInit = async () => {
      const result = await getCompanyProfile(ticker!);
      setCompany(result?.data[0]);
    };
    getProfileInit();
  }, []);

  return (
    <div>
      {company ? (
        <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
          <Sidebar />
          <CompanyDashboard ticker={ticker!}>
            <Tile title="Company Name" subTitle={company.companyName}></Tile>
            <Tile title="Price" subTitle={"$"+company.price.toString()}></Tile>
            <Tile title="DCF" subTitle={"$"+company.dcf.toString()}></Tile>
            <Tile title="Sector" subTitle={company.sector}></Tile>
            

            <CompFinder ticker={company.symbol}/>
            <TenKFinder ticker={company.symbol}/>

            <p className="bg-white shadow rounded text-medium text-gray-900 p-3 mt-1 m-4">
              {company.description}
            </p>

          </CompanyDashboard>
        </div>
      ) : (
        <Spinners/>
      )}
    </div>
  );
};
