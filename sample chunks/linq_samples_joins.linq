' collection of linq for joins, grouping, etc

' Group Join, 3 way join
dim query = from r in Doc_mgmt_reqsts, i in Doc_mgmt_reqst_items, _
	s in Stat_masters _
	where r.Rid = i.Doc_mgmt_reqst_rid _
	and r.Stat_master_rid = s.rid _
	and r.Stat_master_rid < 18 _
	select r.Rid, s.Name_text, i
	
	
Console.WriteLine(query)


' GroupJoin two-way join
dim q = from r in Doc_mgmt_reqsts _
	group join i in Doc_mgmt_reqst_items on r.Rid equals i.Doc_mgmt_reqst_rid into requests = group _
		select new with {r.Rid, r.Stat_master_rid, .ItemCount = requests.Count()}
		
Console.WriteLine(q)

' GroupJoin left outer join
dim q = from s in Stat_masters _
	group join r in Doc_mgmt_reqsts on s.Rid equals r.Stat_master_rid into rqsts = _
		group from rq in rqsts.DefaultIfEmpty _
			select new with {s.Name_text, .Status = rq}
			
Console.WriteLine(q)


' GroupJoin, 4 tables
dim q = from s in Stat_masters _
		from r in Doc_mgmt_reqsts _
		from i in Doc_mgmt_reqst_items _
		from e in Doc_mgmt_reqst_item_entts _
		where s.Rid = r.Stat_master_rid and _
			r.Rid = i.Doc_mgmt_reqst_rid and _
			i.Rid = e.Doc_mgmt_reqst_item_rid _
		select s.Name_Text, r.Creat_dt, i.Doc_id, e.Entt_type_code, e.Entt_val_data
		
			
Console.WriteLine(q)



