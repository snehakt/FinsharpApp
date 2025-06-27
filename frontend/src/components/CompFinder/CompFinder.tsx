import React, { useEffect, useState } from "react";
import { CompanyCompData } from "../../company";
import { getCompData } from "../../api";
import CompFinderItem from "./CompFinderItem/CompFinderItem";

type Props = {
  ticker: string;
};

const CompFinder = ({ ticker }: Props) => {
  const [companyData, setCompanyData] = useState<CompanyCompData>();
  useEffect(() => {
    const getComp = async () => {
      const value = await getCompData(ticker);
      setCompanyData(value?.data[0]);
    };
    getComp();
  }, [ticker]);
  return (
    <div className="inline-flex rounded-md shadow-sm m-4">
     {Array.isArray(companyData?.peersList) &&
  companyData!.peersList.map((ticker) => (
    <CompFinderItem key={ticker} ticker={ticker} />
  ))}
    </div>
  );
};

export default CompFinder;
